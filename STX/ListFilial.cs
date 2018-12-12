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
    public partial class ListFilial : Form
    {
        public ListFilial()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = new Filial().Search(txtFiltrar.Text);
            dataGridView.Refresh();
        }
    }
}
