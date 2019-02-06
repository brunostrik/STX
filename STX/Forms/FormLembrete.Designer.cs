using System;

namespace STX
{
    partial class FormLembrete
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemetente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.dtsDiaLembrete = new STX.DateTimeSelectorStx();
            this.lstDestinatarios = new System.Windows.Forms.ListBox();
            this.lstDestinatariosSelecionados = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRmv = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label7);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.btnRmv);
            this.groupBox.Controls.Add(this.btnAdd);
            this.groupBox.Controls.Add(this.lstDestinatariosSelecionados);
            this.groupBox.Controls.Add(this.lstDestinatarios);
            this.groupBox.Controls.Add(this.dtsDiaLembrete);
            this.groupBox.Controls.Add(this.txtMensagem);
            this.groupBox.Controls.Add(this.txtTitulo);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtRemetente);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Size = new System.Drawing.Size(568, 352);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remetente";
            // 
            // txtRemetente
            // 
            this.txtRemetente.Enabled = false;
            this.txtRemetente.Location = new System.Drawing.Point(88, 45);
            this.txtRemetente.Name = "txtRemetente";
            this.txtRemetente.Size = new System.Drawing.Size(461, 20);
            this.txtRemetente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Assunto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mensagem";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lembrar em";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Destinatários";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(88, 71);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(461, 20);
            this.txtTitulo.TabIndex = 2;
            // 
            // txtMensagem
            // 
            this.txtMensagem.Location = new System.Drawing.Point(88, 97);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensagem.Size = new System.Drawing.Size(461, 110);
            this.txtMensagem.TabIndex = 3;
            // 
            // dtsDiaLembrete
            // 
            this.dtsDiaLembrete.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtsDiaLembrete.EntityProperty = null;
            this.dtsDiaLembrete.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtsDiaLembrete.Location = new System.Drawing.Point(88, 19);
            this.dtsDiaLembrete.Name = "dtsDiaLembrete";
            this.dtsDiaLembrete.Size = new System.Drawing.Size(200, 20);
            this.dtsDiaLembrete.TabIndex = 0;
            this.dtsDiaLembrete.Value = new System.DateTime(2019, 1, 4, 9, 39, 55, 251);
            // 
            // lstDestinatarios
            // 
            this.lstDestinatarios.FormattingEnabled = true;
            this.lstDestinatarios.Location = new System.Drawing.Point(88, 234);
            this.lstDestinatarios.Name = "lstDestinatarios";
            this.lstDestinatarios.Size = new System.Drawing.Size(200, 95);
            this.lstDestinatarios.TabIndex = 4;
            this.lstDestinatarios.SelectedIndexChanged += new System.EventHandler(this.lstDestinatarios_SelectedIndexChanged);
            // 
            // lstDestinatariosSelecionados
            // 
            this.lstDestinatariosSelecionados.FormattingEnabled = true;
            this.lstDestinatariosSelecionados.Location = new System.Drawing.Point(349, 234);
            this.lstDestinatariosSelecionados.Name = "lstDestinatariosSelecionados";
            this.lstDestinatariosSelecionados.Size = new System.Drawing.Size(200, 95);
            this.lstDestinatariosSelecionados.TabIndex = 6;
            this.lstDestinatariosSelecionados.SelectedIndexChanged += new System.EventHandler(this.lstDestinatariosSelecionados_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::STX.Properties.Resources.arrow_right;
            this.btnAdd.Location = new System.Drawing.Point(295, 234);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRmv
            // 
            this.btnRmv.Image = global::STX.Properties.Resources.arrow_left;
            this.btnRmv.Location = new System.Drawing.Point(295, 263);
            this.btnRmv.Name = "btnRmv";
            this.btnRmv.Size = new System.Drawing.Size(48, 23);
            this.btnRmv.TabIndex = 7;
            this.btnRmv.UseVisualStyleBackColor = true;
            this.btnRmv.Click += new System.EventHandler(this.btnRmv_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Disponíveis";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Selecionados";
            // 
            // FormLembrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(593, 393);
            this.MaximizeBox = false;
            this.Name = "FormLembrete";
            this.Text = "Sistema STX - Lembrete Automático";
            this.SalvarPressed += new System.EventHandler(this.FormLembrete_SalvarPressed);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimeSelectorStx dtsDiaLembrete;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemetente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstDestinatariosSelecionados;
        private System.Windows.Forms.ListBox lstDestinatarios;
        private System.Windows.Forms.Button btnRmv;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
