using System;
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

        public void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarPressed(sender, e);
        }

        public void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirPressed(sender, e);
        }
    }
}
