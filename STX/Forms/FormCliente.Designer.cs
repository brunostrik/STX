namespace STX
{
    partial class FormCliente
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
            this.lblNome_NomeFantasia = new System.Windows.Forms.Label();
            this.lblApelido_RazaoSocial = new System.Windows.Forms.Label();
            this.lblCpf_Cnpj = new System.Windows.Forms.Label();
            this.lblDocumentoTipo = new System.Windows.Forms.Label();
            this.cmbTipoPessoa = new System.Windows.Forms.ComboBox();
            this.lblDocumentoNumero = new System.Windows.Forms.Label();
            this.lblDocumentoOrgaoEmissor = new System.Windows.Forms.Label();
            this.dtsDataNascimento = new STX.DateTimeSelectorStx();
            this.lblDataNascimento = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNome_NomeFantasia = new STX.TextBoxStx();
            this.textBoxStx1 = new STX.TextBoxStx();
            this.txtCpf = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.maskedTextBox1);
            this.groupBox.Controls.Add(this.txtCpf);
            this.groupBox.Controls.Add(this.textBoxStx1);
            this.groupBox.Controls.Add(this.txtNome_NomeFantasia);
            this.groupBox.Controls.Add(this.label10);
            this.groupBox.Controls.Add(this.label9);
            this.groupBox.Controls.Add(this.label8);
            this.groupBox.Controls.Add(this.label7);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.lblDataNascimento);
            this.groupBox.Controls.Add(this.dtsDataNascimento);
            this.groupBox.Controls.Add(this.lblDocumentoOrgaoEmissor);
            this.groupBox.Controls.Add(this.lblDocumentoNumero);
            this.groupBox.Controls.Add(this.cmbTipoPessoa);
            this.groupBox.Controls.Add(this.lblDocumentoTipo);
            this.groupBox.Controls.Add(this.lblCpf_Cnpj);
            this.groupBox.Controls.Add(this.lblApelido_RazaoSocial);
            this.groupBox.Controls.Add(this.lblNome_NomeFantasia);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Size = new System.Drawing.Size(694, 377);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Pessoa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNome_NomeFantasia
            // 
            this.lblNome_NomeFantasia.AutoSize = true;
            this.lblNome_NomeFantasia.Location = new System.Drawing.Point(9, 51);
            this.lblNome_NomeFantasia.Name = "lblNome_NomeFantasia";
            this.lblNome_NomeFantasia.Size = new System.Drawing.Size(78, 13);
            this.lblNome_NomeFantasia.TabIndex = 2;
            this.lblNome_NomeFantasia.Text = "Nome Fantasia";
            this.lblNome_NomeFantasia.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblNome_NomeFantasia.Click += new System.EventHandler(this.lblNome_NomeFantasia_Click);
            // 
            // lblApelido_RazaoSocial
            // 
            this.lblApelido_RazaoSocial.AutoSize = true;
            this.lblApelido_RazaoSocial.Location = new System.Drawing.Point(17, 85);
            this.lblApelido_RazaoSocial.Name = "lblApelido_RazaoSocial";
            this.lblApelido_RazaoSocial.Size = new System.Drawing.Size(70, 13);
            this.lblApelido_RazaoSocial.TabIndex = 3;
            this.lblApelido_RazaoSocial.Text = "Razão Social";
            this.lblApelido_RazaoSocial.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblApelido_RazaoSocial.Click += new System.EventHandler(this.lblApelido_RazaoSocial_Click);
            // 
            // lblCpf_Cnpj
            // 
            this.lblCpf_Cnpj.AutoSize = true;
            this.lblCpf_Cnpj.Location = new System.Drawing.Point(53, 112);
            this.lblCpf_Cnpj.Name = "lblCpf_Cnpj";
            this.lblCpf_Cnpj.Size = new System.Drawing.Size(34, 13);
            this.lblCpf_Cnpj.TabIndex = 4;
            this.lblCpf_Cnpj.Text = "CNPJ";
            this.lblCpf_Cnpj.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblCpf_Cnpj.Click += new System.EventHandler(this.lblCpf_Cnpj_Click);
            // 
            // lblDocumentoTipo
            // 
            this.lblDocumentoTipo.AutoSize = true;
            this.lblDocumentoTipo.Location = new System.Drawing.Point(25, 137);
            this.lblDocumentoTipo.Name = "lblDocumentoTipo";
            this.lblDocumentoTipo.Size = new System.Drawing.Size(62, 13);
            this.lblDocumentoTipo.TabIndex = 5;
            this.lblDocumentoTipo.Text = "Documento";
            this.lblDocumentoTipo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDocumentoTipo.Click += new System.EventHandler(this.lblDocumentoTipo_Click);
            // 
            // cmbTipoPessoa
            // 
            this.cmbTipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPessoa.FormattingEnabled = true;
            this.cmbTipoPessoa.Items.AddRange(new object[] {
            "Pessoa Física",
            "Pessoa Jurídica"});
            this.cmbTipoPessoa.Location = new System.Drawing.Point(93, 13);
            this.cmbTipoPessoa.Name = "cmbTipoPessoa";
            this.cmbTipoPessoa.Size = new System.Drawing.Size(172, 21);
            this.cmbTipoPessoa.TabIndex = 6;
            // 
            // lblDocumentoNumero
            // 
            this.lblDocumentoNumero.AutoSize = true;
            this.lblDocumentoNumero.Location = new System.Drawing.Point(221, 137);
            this.lblDocumentoNumero.Name = "lblDocumentoNumero";
            this.lblDocumentoNumero.Size = new System.Drawing.Size(44, 13);
            this.lblDocumentoNumero.TabIndex = 7;
            this.lblDocumentoNumero.Text = "Número";
            this.lblDocumentoNumero.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDocumentoNumero.Click += new System.EventHandler(this.lblDocumentoNumero_Click);
            // 
            // lblDocumentoOrgaoEmissor
            // 
            this.lblDocumentoOrgaoEmissor.AutoSize = true;
            this.lblDocumentoOrgaoEmissor.Location = new System.Drawing.Point(352, 134);
            this.lblDocumentoOrgaoEmissor.Name = "lblDocumentoOrgaoEmissor";
            this.lblDocumentoOrgaoEmissor.Size = new System.Drawing.Size(75, 13);
            this.lblDocumentoOrgaoEmissor.TabIndex = 8;
            this.lblDocumentoOrgaoEmissor.Text = "Órgão Emissor";
            this.lblDocumentoOrgaoEmissor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDocumentoOrgaoEmissor.Click += new System.EventHandler(this.lblDocumentoOrgaoEmissor_Click);
            // 
            // dtsDataNascimento
            // 
            this.dtsDataNascimento.CustomFormat = "dd/MM/yyyy";
            this.dtsDataNascimento.EntityProperty = null;
            this.dtsDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtsDataNascimento.Location = new System.Drawing.Point(571, 50);
            this.dtsDataNascimento.Name = "dtsDataNascimento";
            this.dtsDataNascimento.Size = new System.Drawing.Size(108, 20);
            this.dtsDataNascimento.TabIndex = 9;
            this.dtsDataNascimento.Value = new System.DateTime(2019, 1, 24, 9, 14, 36, 84);
            // 
            // lblDataNascimento
            // 
            this.lblDataNascimento.AutoSize = true;
            this.lblDataNascimento.Location = new System.Drawing.Point(461, 51);
            this.lblDataNascimento.Name = "lblDataNascimento";
            this.lblDataNascimento.Size = new System.Drawing.Size(104, 13);
            this.lblDataNascimento.TabIndex = 10;
            this.lblDataNascimento.Text = "Data de Nascimento";
            this.lblDataNascimento.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDataNascimento.Click += new System.EventHandler(this.lblDataNascimento_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Celular/WhatsApp";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Telefone";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "E-Mail";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Endereço";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(436, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Número";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Complemento";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Bairro";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(359, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Cidade";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(406, 285);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "UF";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNome_NomeFantasia
            // 
            this.txtNome_NomeFantasia.EntityProperty = null;
            this.txtNome_NomeFantasia.Location = new System.Drawing.Point(93, 48);
            this.txtNome_NomeFantasia.Name = "txtNome_NomeFantasia";
            this.txtNome_NomeFantasia.Required = false;
            this.txtNome_NomeFantasia.Size = new System.Drawing.Size(276, 20);
            this.txtNome_NomeFantasia.TabIndex = 20;
            // 
            // textBoxStx1
            // 
            this.textBoxStx1.EntityProperty = null;
            this.textBoxStx1.Location = new System.Drawing.Point(93, 82);
            this.textBoxStx1.Name = "textBoxStx1";
            this.textBoxStx1.Required = false;
            this.textBoxStx1.Size = new System.Drawing.Size(586, 20);
            this.textBoxStx1.TabIndex = 21;
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(93, 112);
            this.txtCpf.Mask = "00,000,000/0000-00";
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(100, 20);
            this.txtCpf.TabIndex = 22;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(93, 138);
            this.maskedTextBox1.Mask = "000,000,000-00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 23;
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(719, 418);
            this.Name = "FormCliente";
            this.Text = "Sistema STX - Cliente";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApelido_RazaoSocial;
        private System.Windows.Forms.Label lblNome_NomeFantasia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCpf_Cnpj;
        private System.Windows.Forms.Label lblDocumentoOrgaoEmissor;
        private System.Windows.Forms.Label lblDocumentoNumero;
        private System.Windows.Forms.ComboBox cmbTipoPessoa;
        private System.Windows.Forms.Label lblDocumentoTipo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDataNascimento;
        private DateTimeSelectorStx dtsDataNascimento;
        private TextBoxStx txtNome_NomeFantasia;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox txtCpf;
        private TextBoxStx textBoxStx1;
    }
}
