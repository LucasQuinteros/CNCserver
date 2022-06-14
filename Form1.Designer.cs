namespace server_cliente_thread
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Consola_box = new System.Windows.Forms.TextBox();
            this.Server_on_boton = new System.Windows.Forms.Button();
            this.IP_box = new System.Windows.Forms.TextBox();
            this.Port_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Clientes_listView1 = new System.Windows.Forms.ListView();
            this.Client_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Archivos_listView2 = new System.Windows.Forms.ListView();
            this.Files = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.direccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarArchivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClicktMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enviarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.RightClicktMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Consola_box
            // 
            this.Consola_box.Location = new System.Drawing.Point(13, 157);
            this.Consola_box.Multiline = true;
            this.Consola_box.Name = "Consola_box";
            this.Consola_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Consola_box.Size = new System.Drawing.Size(447, 328);
            this.Consola_box.TabIndex = 2;
            // 
            // Server_on_boton
            // 
            this.Server_on_boton.Location = new System.Drawing.Point(13, 99);
            this.Server_on_boton.Name = "Server_on_boton";
            this.Server_on_boton.Size = new System.Drawing.Size(448, 23);
            this.Server_on_boton.TabIndex = 3;
            this.Server_on_boton.Text = "Start Server";
            this.Server_on_boton.UseVisualStyleBackColor = true;
            this.Server_on_boton.Click += new System.EventHandler(this.button2_Click);
            // 
            // IP_box
            // 
            this.IP_box.Location = new System.Drawing.Point(80, 64);
            this.IP_box.Name = "IP_box";
            this.IP_box.Size = new System.Drawing.Size(100, 20);
            this.IP_box.TabIndex = 5;
            // 
            // Port_box
            // 
            this.Port_box.Location = new System.Drawing.Point(342, 64);
            this.Port_box.Name = "Port_box";
            this.Port_box.Size = new System.Drawing.Size(100, 20);
            this.Port_box.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Port";
            // 
            // Clientes_listView1
            // 
            this.Clientes_listView1.BackColor = System.Drawing.SystemColors.Window;
            this.Clientes_listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Client_status,
            this.id,
            this.columnHeader1});
            this.Clientes_listView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Clientes_listView1.FullRowSelect = true;
            this.Clientes_listView1.Location = new System.Drawing.Point(484, 64);
            this.Clientes_listView1.Name = "Clientes_listView1";
            this.Clientes_listView1.Size = new System.Drawing.Size(368, 181);
            this.Clientes_listView1.TabIndex = 16;
            this.Clientes_listView1.UseCompatibleStateImageBehavior = false;
            this.Clientes_listView1.View = System.Windows.Forms.View.Details;
            this.Clientes_listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Client_status
            // 
            this.Client_status.Text = "Estado";
            this.Client_status.Width = 160;
            // 
            // id
            // 
            this.id.Text = "IP";
            this.id.Width = 110;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Progreso";
            // 
            // Archivos_listView2
            // 
            this.Archivos_listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Files,
            this.direccion});
            this.Archivos_listView2.FullRowSelect = true;
            this.Archivos_listView2.Location = new System.Drawing.Point(484, 285);
            this.Archivos_listView2.MultiSelect = false;
            this.Archivos_listView2.Name = "Archivos_listView2";
            this.Archivos_listView2.Size = new System.Drawing.Size(368, 200);
            this.Archivos_listView2.TabIndex = 17;
            this.Archivos_listView2.UseCompatibleStateImageBehavior = false;
            this.Archivos_listView2.View = System.Windows.Forms.View.Details;
            this.Archivos_listView2.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.Archivos_listView2_ItemChecked);
            this.Archivos_listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.Archivos_listView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseDown);
            // 
            // Files
            // 
            this.Files.Text = "Archivos";
            this.Files.Width = 76;
            // 
            // direccion
            // 
            this.direccion.Text = "Ubicacion";
            this.direccion.Width = 288;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(862, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFilesToolStripMenuItem,
            this.quitarArchivosToolStripMenuItem,
            this.enviarToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.filesToolStripMenuItem.Text = "Archivos";
            // 
            // newFilesToolStripMenuItem
            // 
            this.newFilesToolStripMenuItem.Name = "newFilesToolStripMenuItem";
            this.newFilesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.newFilesToolStripMenuItem.Text = "Agregar archivos";
            this.newFilesToolStripMenuItem.Click += new System.EventHandler(this.newFilesToolStripMenuItem_Click);
            // 
            // quitarArchivosToolStripMenuItem
            // 
            this.quitarArchivosToolStripMenuItem.Name = "quitarArchivosToolStripMenuItem";
            this.quitarArchivosToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.quitarArchivosToolStripMenuItem.Text = "Quitar archivos";
            this.quitarArchivosToolStripMenuItem.Click += new System.EventHandler(this.quitarArchivosToolStripMenuItem_Click);
            // 
            // enviarToolStripMenuItem
            // 
            this.enviarToolStripMenuItem.Name = "enviarToolStripMenuItem";
            this.enviarToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.enviarToolStripMenuItem.Text = "Enviar archivo seleccionado";
            this.enviarToolStripMenuItem.Click += new System.EventHandler(this.enviarToolStripMenuItem_Click);
            // 
            // RightClicktMenuStrip1
            // 
            this.RightClicktMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarArchivoToolStripMenuItem,
            this.borrarToolStripMenuItem});
            this.RightClicktMenuStrip1.Name = "RightClicktMenuStrip1";
            this.RightClicktMenuStrip1.Size = new System.Drawing.Size(110, 48);
            // 
            // enviarArchivoToolStripMenuItem
            // 
            this.enviarArchivoToolStripMenuItem.Name = "enviarArchivoToolStripMenuItem";
            this.enviarArchivoToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.enviarArchivoToolStripMenuItem.Text = "Enviar ";
            this.enviarArchivoToolStripMenuItem.Click += new System.EventHandler(this.enviarArchivoToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.borrarToolStripMenuItem.Text = "Borrar ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(481, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Archivo seleccionado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(481, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "IP Maquina seleccionada:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(651, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(199, 20);
            this.textBox1.TabIndex = 21;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(651, 256);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(199, 20);
            this.textBox2.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(862, 497);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Archivos_listView2);
            this.Controls.Add(this.Clientes_listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Port_box);
            this.Controls.Add(this.IP_box);
            this.Controls.Add(this.Server_on_boton);
            this.Controls.Add(this.Consola_box);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RightClicktMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Consola_box;
        private System.Windows.Forms.Button Server_on_boton;
        private System.Windows.Forms.TextBox IP_box;
        private System.Windows.Forms.TextBox Port_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView Clientes_listView1;
        private System.Windows.Forms.ColumnHeader Client_status;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ListView Archivos_listView2;
        private System.Windows.Forms.ColumnHeader Files;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitarArchivosToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader direccion;
        private System.Windows.Forms.ToolStripMenuItem enviarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip RightClicktMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enviarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

