using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections.Specialized;

namespace server_cliente_thread
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private String Cliente_seleccionado = null;
        //public StreamReader STR;
        //public StreamWriter STW;
        public String receive;
        public String text_to_send;
        public Thread mihilo;
        String Atributo;
        public Thread Proceso_cliente;
        public TcpListener escuchador;
        private Hilos _servidor;
        public static List<Info_cliente> Lista_clientes = new List<Info_cliente>();
        public static ListView Lista_de_clientes = new ListView();
        private string path_file;
        private bool Fin_del_servidor = false;
        public Form1()
        {

            InitializeComponent();
            Port_box.Text = "1234";

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress adress in localIP)
            {
                if (adress.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP_box.Text = adress.ToString();

                }
            }

        }       // Inicio de programa

        #region SERVIDOR
        private void button2_Click(object sender, EventArgs e) // Inicio de server boton SERVER ON
        {                       
            //escuchador = new TcpListener(IPAddress.Any, int.Parse(textBox4.Text));
            _servidor = new Hilos();            
            _servidor.Startserver(Port_box.Text);
            _servidor.Cambio_de_estado += new Hilos.HilostatusEventHandler(Cambiodeestado);
            _servidor.HilosProgressChanged += new Hilos.HiloprogressEventHandler(Cambiodeprogreso);
            //mihilo = new Thread(HiloPrincipal.Startserver);//para iniciar un thread parametrizado debo mandar el dato como object
            //mihilo.Start(textBox4.Text);
            
        }

        #endregion 

        void Func_atencion(object Client) // RECEPCION DE DATOS
        {

            Info_cliente x = (Info_cliente)Client;

            string receive;
            for (;;)
            {
                try
                {
                    receive = x.STR.ReadLine();
                    if (receive == "alarma")
                    {
                        //cambiarcolor(receive);
                    }
                    else
                        IP_box.Text = ("Friend : " + receive + "\n");
                }
                catch (Exception y)
                {
                    IP_box.Text = y.Message.ToString() + "\n";
                }
            }


        }

        #region Llamado de controles    Funciones para llamar al control desde el thread
        public delegate void writeValue(TextBox donde, string text); 
        public void text2(TextBox donde, string texto)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new writeValue(text2), donde, texto);
            }
            else
            {
                donde.AppendText(texto);

            }

        }
        #endregion


        private void button1_Click(object sender, EventArgs e) // ENVIO DE DATOS
        {

        } 

        private void Cambiodeestado(object sender, Eventos e)
        {
            
            switch (e.Status)
            {
                case HiloStatus.Corriendo:
                    //Enviar_boton.Enabled = true;
                    Server_on_boton.Enabled = false;
                    //button3.Enabled = false;
                    Consola_box.AppendText("\t"+"\t"+"\t"+"\t"+"Servidor ON"+"\n");
                    
                    break;

                case HiloStatus.Parado:
                    //Enviar_boton.Enabled = false;
                    Server_on_boton.Enabled = true;
                    //button3.Enabled = false;
                    Consola_box.AppendText("\t" + "\t" + "\t" + "\t" + "Servidor OFF" + "\n");
                    break;
            }
        } // ESTADO DEL SERVER

        private void Cambiodeprogreso(object sender, Eventos e) //INFORMES DESDE THREADS HASTA PANTALLA
        {
            string id = "";
            int Nmaquina = 0;
            switch (e.Progress)
            {
                case HiloStatus.Cliente_nuevo:
                    //Status_conect_box.AppendText("Nuevo cliente conectado: " + e.datos + "\n");
                    ListViewItem item1 = new ListViewItem("Conectado");
                    
                    item1.SubItems.Add(e.datos);
                    
                    item1.SubItems.Add("0%");
                    Nmaquina++;
                    Clientes_listView1.Items.Add(item1);

                    Consola_box.AppendText("Conexion entrante de: " + e.datos + "\n");
                    break;
                case HiloStatus.Datos:
                    
                    if (e.datos.Contains("%"))
                    {
                        //Consola_box.AppendText("friend:" + e.datos + "\n");
                        id = e.datos.Substring(e.datos.IndexOf("%")+1);
                        //Consola_box.AppendText(id);
                        var item = Clientes_listView1.FindItemWithText(id);
                        item.SubItems[2].Text = e.datos.Substring(0,e.datos.IndexOf("%") + 1);
                    }
                    break;
                case HiloStatus.Cliente_desconectado:
                    Consola_box.AppendText("Cliente desconectado: " + e.datos + "\n");
                    //Status_conect_box.AppendText("Cliente desconectado: " + e.datos+"\n");
                    textBox1.Text = "";
                    Clientes_listView1.Items.Remove( Clientes_listView1.FindItemWithText(e.datos));
                    break;
                case HiloStatus.Dato_enviar:
                  
                    break;
                case HiloStatus.Dato_enviado:
                    
                    break;
                case HiloStatus.Cliente_inexistente:
                    Consola_box.AppendText("No se encontro el cliente");
                    break;


            }
        }

        public void refrescar_lista()
        {
            //Status_conect_box.Text = "";
            foreach (Info_cliente x in Lista_clientes)
            {
                //Status_conect_box.AppendText("hola");
            }
        }

        public void listener_start()
        {
            text2(Consola_box, "Server ON" + "\n");
            while (!Fin_del_servidor)
            {
                //escuchador.Start();
                client = escuchador.AcceptTcpClient();

                //Info_cliente _client = new Info_cliente(client, textBox2, textBox7);
                Proceso_cliente = new Thread(Func_atencion);
                Info_cliente Client = new Info_cliente(client);
                Proceso_cliente.Start(Client);
                Consola_box.Text = "Conexion establecida con" + Client.id + "\n";
                Lista_clientes.Add(Client);
                refrescar_lista();
                

            }
            Consola_box.Text = "OK";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Clientes_listView1.Items[0].SubItems[1].Text;
            Cliente_seleccionado = Clientes_listView1.Items[0].SubItems[1].Text;
            Clientes_listView1.Items[0].SubItems[1].BackColor = Color.Red;
        }

        private void newFilesToolStripMenuItem_Click(object sender, EventArgs e)       {
            OpenFileDialog OpenFilaDialog1 = new OpenFileDialog();
            OpenFilaDialog1.AddExtension = false;
            try
            {
                if(OpenFilaDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    ListViewItem item1 = new ListViewItem(OpenFilaDialog1.SafeFileName);
                    item1.SubItems.Add(OpenFilaDialog1.FileName);
                    //item1.SubItems.Add();
                    Archivos_listView2.Items.Add(item1);
                    
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void quitarArchivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Archivos_listView2.SelectedItems.Count > 0)
            {
                while (Archivos_listView2.SelectedItems.Count != 0) {
                    Archivos_listView2.SelectedItems[0].Remove();
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Archivos_listView2.SelectedItems.Count > 0)
            {
                path_file = Archivos_listView2.SelectedItems[0].SubItems[1].Text;
                textBox2.Text = Archivos_listView2.SelectedItems[0].SubItems[0].Text;
            }

        }

        private void listView2_MouseDown(object sender, MouseEventArgs e)
        {
            if(Archivos_listView2.SelectedItems.Count != 0)
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {                        
                        RightClicktMenuStrip1.Show(this, new Point(e.X+484, e.Y+251)); 
                    }
                    break;
            }
        }

        private void enviarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fin_del_servidor = true;
            
        }

        private void enviarToolStripMenuItem_Click(object sender, EventArgs e)
        {      
            if(Cliente_seleccionado !=null)
                if (path_file != null)
                {
                    var file = new FileStream(path_file, FileMode.Open, FileAccess.Read);
                    Consola_box.AppendText(Cliente_seleccionado + "\n");
                    Consola_box.AppendText("Enviando archivo seleccionado \n");
                    _servidor.SendMessage("#FILE", Cliente_seleccionado);
                    using (var streamReader = new StreamReader(file, Encoding.UTF8))
                    {
                        _servidor.SendMessage(textBox2.Text,Cliente_seleccionado);
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                            _servidor.SendMessage(line, Cliente_seleccionado);                            
                        }
                        
                    }
                    _servidor.SendMessage("#FINFILE", Cliente_seleccionado);
                }
        }

        private void Archivos_listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Lista.Clear();
            var Archivos_lista = new List<string>();
            foreach (ListViewItem Item in Archivos_listView2.Items)
            {

                Archivos_lista.Add(Item.Text.ToString());
                Archivos_lista.Add(Item.SubItems[1].Text);
            }

            StringCollection collection = new StringCollection();
            collection.AddRange(Archivos_lista.ToArray());
            Properties.Settings.Default.Lista = collection;
            Properties.Settings.Default.Save(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (Properties.Settings.Default.Lista != null)
            {
                //create a new collection again
                StringCollection collection = new StringCollection();
                //set the collection from the settings variable
                collection = Properties.Settings.Default.Lista;
                //convert the collection back to a list
                List<string> followedList = collection.Cast<string>().ToList();
                //populate the listview again from the new list
                Console.WriteLine(followedList.Count());

                for (int i=0; i<followedList.Count() ;i+=2)
                {
                    ListViewItem item1 = new ListViewItem(followedList[i]);
                    item1.SubItems.Add(followedList[i+1]);
                    Archivos_listView2.Items.Add(item1);
                    
                }
                
            }
            //Properties.Settings.Default.Lista.Clear();
        }
    }
}
