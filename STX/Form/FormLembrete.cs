using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace STX
{
    public partial class FormLembrete : STX.FormStxBase
    {
        Lembrete entity;
        public FormLembrete(Lembrete e, IListForm listaRetorno)
        {
            InitializeComponent();
            ListaRetorno = listaRetorno;
            entity = e;
        }

        private void FormLembrete_SalvarPressed(object sender, EventArgs e)
        {

        }

        private void FormLembrete_ExcluirPressed(object sender, EventArgs e)
        {
            Alerts.Alert("CU");
        }
    }
}
