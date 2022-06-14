using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;


namespace server_cliente_thread
{
    public class Hilos
    {
        private HiloStatus _hilostate;
        private delegate void Hilodelegate(string Port);
        private delegate string Hilodelegate2(Info_cliente Cliente);
        private delegate void Hilodelegate3(string mensaje, string direccion);
        private delegate void clientedel(TcpClient client);
        private List<Info_cliente> Clientes = new List<Info_cliente>();

        public delegate void HilostatusEventHandler(object sender, Eventos e);
        public delegate void HiloprogressEventHandler(object sender, Eventos e);

        public event HilostatusEventHandler Cambio_de_estado;
        public event HiloprogressEventHandler HilosProgressChanged;

        public Hilos() {

            _hilostate = HiloStatus.Parado;
        }

        public void Startserver(string Port)
        {
            lock (this)
            {
                if (_hilostate == HiloStatus.Parado)
                {
                    Hilodelegate del= new Hilodelegate(Escuchador);

                    del.BeginInvoke(Port, new AsyncCallback(Findelservidor), del);

                    _hilostate = HiloStatus.Corriendo;

                    Disparadordecambiodeestado(_hilostate);
                }
            }
        }

        public void SendMessage(string text_to_send, string direccion)
        {
            
            Hilodelegate3 del3 = new Hilodelegate3(Envio_al_cliente);
            del3.BeginInvoke(text_to_send,direccion, new AsyncCallback(Fin_de_envio), del3);
        }

        private void Envio_al_cliente(string text_to_send, string direccion)
        {
            List<Info_cliente> Cliente2 = new List<Info_cliente>();
            Info_cliente objetivo = new Info_cliente();
            Cliente2.Add(objetivo);
            //objetivo.socket_client = null;

            foreach (Info_cliente x in Clientes)
            {
                if (x.id == direccion)
                    objetivo = x;
            }
            if (objetivo.id != "")
            {
                if (objetivo.socket_client.Connected)
                {
                    try
                    {
                        objetivo.STW.WriteLine(text_to_send,Encoding.UTF8);
                        Disparadordecambiodeprogreso(HiloStatus.Dato_enviar, text_to_send);
                    }
                    catch (Exception e)
                    {
                        Disparadordecambiodeprogreso(HiloStatus.Datos, e.ToString());
                    }
                }
            }
            else
                Disparadordecambiodeprogreso(HiloStatus.Cliente_inexistente, "");

        }

        private void Fin_de_envio(IAsyncResult ar)
        {
            Hilodelegate3 del = (Hilodelegate3)ar.AsyncState;
            del.EndInvoke(ar);
            
            lock (this)
            {
                Disparadordecambiodeprogreso(HiloStatus.Dato_enviado, "");
            }
        }

        private void Escuchador(string Port) {
            //Comienza el listener
            TcpListener Listener = new TcpListener(IPAddress.Any, int.Parse((string)Port));
            
            try {
                Listener.Start();
                 }
            catch (Exception e){
                MessageBox.Show("El escuchador no pudo iniciar"+ e.ToString());

            }
            Disparadordecambiodeestado(HiloStatus.Corriendo);            
            for (;;)
            {                
                Info_cliente Nuevo_cliente = new Info_cliente(Listener.AcceptTcpClient());
                Clientes.Add(Nuevo_cliente);
                Hilodelegate2 del2 = new Hilodelegate2(Atencion_de_cliente);
                del2.BeginInvoke(Nuevo_cliente, new AsyncCallback (fin_de_cliente), del2);

                Disparadordecambiodeprogreso(HiloStatus.Cliente_nuevo, Nuevo_cliente.id);
            }
        }

        private String Atencion_de_cliente(Info_cliente Nuevo_cliente)
        {
            bool Vivo = true;

            while(Nuevo_cliente.socket_client.Connected && Vivo)
            {
                try
                {
                    String hola = Nuevo_cliente.STR.ReadLine();
                    if (hola == null || hola == "###")
                    {
                        Vivo = false;
                    }           
                    else
                    Disparadordecambiodeprogreso(HiloStatus.Datos, hola + Nuevo_cliente.id);

                }
                catch(Exception e)
                {
                    if(Vivo == true)
                    Disparadordecambiodeprogreso(HiloStatus.Datos, e.ToString());                   
                }
            }
            string IP = Nuevo_cliente.id;
            Clientes.Remove(Nuevo_cliente);
            Nuevo_cliente.STR.Close();
            Nuevo_cliente.socket_client.Close();
            return IP;
        }

        private void fin_de_cliente(IAsyncResult ar)
        {
            Hilodelegate2 del =(Hilodelegate2) ar.AsyncState;
            string result = del.EndInvoke(ar);
            lock (this)
            {
                Disparadordecambiodeprogreso(HiloStatus.Cliente_desconectado, result);
            }
        }

        private void Findelservidor(IAsyncResult ar) {

            Hilodelegate del = (Hilodelegate)ar.AsyncState;
            del.EndInvoke(ar);
            lock (this)
            {
                _hilostate = HiloStatus.Parado;
                Disparadordecambiodeestado(_hilostate);
            }

        }

        private void Disparadordecambiodeestado(HiloStatus estado)
        {
            if(Cambio_de_estado != null)
            {
                Eventos args = new Eventos(estado);
                if( Cambio_de_estado.Target is System.Windows.Forms.Control)
                {
                    Control targetForm = Cambio_de_estado.Target as System.Windows.Forms.Control;
                    targetForm.Invoke(Cambio_de_estado, new object[] { this, args });
                }
                else
                {
                    Cambio_de_estado(this, args);
                }
            }
        }

        private void Disparadordecambiodeprogreso(HiloStatus progress, string datos)
        {
            if( HilosProgressChanged != null)
            {
                Eventos args = new Eventos(progress,datos);
                if (HilosProgressChanged.Target is System.Windows.Forms.Control)
                {
                    Control targetForm = HilosProgressChanged.Target as System.Windows.Forms.Control;
                    targetForm.Invoke(HilosProgressChanged, new object[] { this, args });
                }
                else
                {
                    HilosProgressChanged(this, args);
                }
            }
        }


    }
    public enum HiloStatus
    {
        Corriendo, Parado, Datos , Server_on,Cliente_nuevo,Cliente_desconectado,Dato_enviar,Dato_enviado, Cliente_inexistente
    }

    public class Eventos : EventArgs
    {
        public string Result;
        public HiloStatus Progress;
        public HiloStatus Status;
        public string datos = null;
        public string identidad = null;
        public Eventos(HiloStatus estado)
        {
            this.Status = estado;
            
        }
        public Eventos(HiloStatus progress, string datos)
        {
            this.Progress = progress;
            this.Status = HiloStatus.Corriendo;
            this.datos = datos;
        
        }
    }

    public class Info_cliente
    {

        static Thread recepcion,sender;
        public TcpClient socket_client;
        public string id;
        private static TextBox Consola, txt7;
        public StreamReader STR;
        public StreamWriter STW;
        public Info_cliente(TcpClient c)
        {                        
            socket_client = c;
            id = c.Client.RemoteEndPoint.ToString();
            
            STR = new StreamReader(c.GetStream());
            STW = new StreamWriter(c.GetStream());
            STW.AutoFlush = true;
            //recepcion = new Thread(data_in);
            //recepcion.Start(c);
            //sender = new Thread(data_out);
            //sender.Start(c);
        }
        public Info_cliente() {
            id = "";
        }

        //public void data_in(object csockt)
        //{
        //    TcpClient cliente = (TcpClient) csockt;
        //    string IP = cliente.Client.RemoteEndPoint.ToString();
        //    StreamReader STR;
        //    STR = new StreamReader(cliente.GetStream());
        //    //STR.AutoFlush = true;
        //    while (cliente.Connected)
        //    {                
        //        try
        //        {
                    
        //            string receive = STR.ReadLine();
        //            if(receive == "alarma")
        //            {
        //                cambiarcolor(receive);
        //            }
        //            else
        //            text3(Consola,("Friend : " + receive + "\n"));

        //            //Consola.Invoke(new MethodInvoker(delegate () { Consola.AppendText("Friend : " + receive + "\n"); }));
        //        }
        //        catch(Exception x)
        //        {
                    
        //            //MessageBox.Show(x.Message.ToString() + "\n");
        //            text3(Consola, x.Message.ToString() + "\n");

        //        }
                
        //    }
        //    text3(Consola, IP + "Se ha desconectado" + "\n");

        //    //Consola.Invoke(new MethodInvoker(delegate () { Consola.AppendText(IP + "Se ha desconectado" + "\n"); }));
        //    STR.Close();
        //    cliente.Client.Close();
        //    Borrar_cliente(IP);
        //    recepcion.Abort();
        //    // sender.Abort();
            
        //}
        public void data_out(object send)
        {
            TcpClient cliente = this.socket_client;

            string IP = cliente.Client.RemoteEndPoint.ToString();
            StreamWriter STW;
            STW = new StreamWriter(cliente.GetStream());
            STW.AutoFlush = true;
            if (cliente.Connected)
            {
                try
                {
                    STW.WriteLine((string)send);
                    //text3(Consola, ("Friend : " + send + "\n"));
                    //Consola.Invoke(new MethodInvoker(delegate () { Consola.AppendText("Friend : " + receive + "\n"); }));
                }
                catch (Exception x)
                {

                    //MessageBox.Show(x.Message.ToString() + "\n");
                    text3(Consola, x.Message.ToString() + "\n");
                    STW.Close();
                    if (!cliente.Connected)
                    {
                        text3(Consola, IP + "Se ha desconectado" + "\n");
                        //Consola.Invoke(new MethodInvoker(delegate () { Consola.AppendText(IP + "Se ha desconectado" + "\n"); }));
                        Borrar_cliente(IP);
                        cliente.Client.Close();
                        recepcion.Abort();
                    }
                }

            }
            //STW.Close();
            // sender.Abort();
        }
        //private void cambiarcolor(string x)
        //{
            
        //    Form1.button4.BackColor= System.Drawing.Color.Red;
        //}

        public delegate void write(TextBox Consola, string texto);
        public delegate void erase(TextBox Consola);

        private static void Borrar_cliente(string IP)
        {
            text3(txt7);
            int index = -1;
            foreach (Info_cliente x in Form1.Lista_clientes)
            {
                if (x.id == IP)
                {
                    index = Form1.Lista_clientes.IndexOf(x);
                }
                else
                    text3(txt7, x.id + "\n");
            }
            if(index >= 0)
            Form1.Lista_clientes.RemoveAt(index);
        }

        public static  void  text3(TextBox Consola, string texto)
        {
            if (Consola.InvokeRequired)
            {
                Consola.Invoke(new write(text3),Consola, texto);
            }
            else
            {
                Consola.AppendText(texto);

            }
        }

        public static void text3(TextBox Consola)
        {
            if (Consola.InvokeRequired)
            {
                Consola.Invoke(new erase(text3), Consola);
            }
            else
            {
                Consola.Text = "";

            }
        }

    }
    }



