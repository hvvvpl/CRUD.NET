namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNome = new TextBox();
            txtTelefone = new TextBox();
            txtEmail = new TextBox();
            button1 = new Button();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            listContatos = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            label4 = new Label();
            txtBuscar = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 9);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 62);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 1;
            label2.Text = "Telefone:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 116);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 2;
            label3.Text = "E-mail:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 27);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(292, 23);
            txtNome.TabIndex = 3;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(12, 80);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(292, 23);
            txtTelefone.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 134);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(292, 23);
            txtEmail.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(218, 181);
            button1.Name = "button1";
            button1.Size = new Size(86, 27);
            button1.TabIndex = 6;
            button1.Text = "Salvar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // listContatos
            // 
            listContatos.ContextMenuStrip = contextMenuStrip1;
            listContatos.Location = new Point(331, 56);
            listContatos.MultiSelect = false;
            listContatos.Name = "listContatos";
            listContatos.Size = new Size(418, 283);
            listContatos.TabIndex = 7;
            listContatos.UseCompatibleStateImageBehavior = false;
            listContatos.ItemSelectionChanged += listContatos_ItemSelectionChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(109, 26);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(108, 22);
            toolStripMenuItem1.Text = "Excluir";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(330, 9);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 8;
            label4.Text = "Buscar Contato:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(330, 27);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(338, 23);
            txtBuscar.TabIndex = 9;
            // 
            // button2
            // 
            button2.Location = new Point(674, 26);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "Buscar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 181);
            button3.Name = "button3";
            button3.Size = new Size(86, 27);
            button3.TabIndex = 11;
            button3.Text = "Novo";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(115, 183);
            button4.Name = "button4";
            button4.Size = new Size(86, 25);
            button4.TabIndex = 12;
            button4.Text = "Excluir";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 351);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(txtBuscar);
            Controls.Add(label4);
            Controls.Add(listContatos);
            Controls.Add(button1);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefone);
            Controls.Add(txtNome);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Agenda de contatos | CRUD com C# & MySql";
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNome;
        private TextBox txtTelefone;
        private TextBox txtEmail;
        private Button button1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private ListView listContatos;
        private Label label4;
        private TextBox txtBuscar;
        private Button button2;
        private Button button3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private Button button4;
    }
}
