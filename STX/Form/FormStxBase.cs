using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STX
{
    public partial class FormStxBase : Form
    {

        public IListForm ListaRetorno;

        public event EventHandler SalvarPressed;
        public event EventHandler ExcluirPressed;

        public FormStxBase()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarPressed(sender, e);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirPressed(sender, e);
        }
    }
}
