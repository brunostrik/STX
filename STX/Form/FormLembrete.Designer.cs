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
            this.SuspendLayout();
            // 
            // FormLembrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(654, 393);
            this.Name = "FormLembrete";
            this.SalvarPressed += new System.EventHandler(this.FormLembrete_SalvarPressed);
            this.ExcluirPressed += new System.EventHandler(this.FormLembrete_ExcluirPressed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
