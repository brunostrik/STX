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
    public partial class ListFilial : Form, IListForm
    {

        private ISelector returnClass;
        private List<Object> listItems;
        private Filial itemSelecionado;

        public ListFilial(ISelector returnSelector = null)
        {
            InitializeComponent();
            this.returnClass = returnSelector;
            if (this.returnClass != null)
            {
                this.Text = Program.APP_NAME + " - Selecione uma " + "Filial";
            }else
            {
                this.Text = Program.APP_NAME + " - " + "Filiais";
            }
            btnAtualizar_Click(null, null);
        }

        private void CarregarDados(string filtro = "")
        {
            listItems = new Filial().Search(filtro);
            dataGridView.DataSource = listItems;
            dataGridView.Refresh();
            AlternarBotoes();
        }
        private void NovoItem()
        {
            Program.formFilial = new FormFilial(new Filial());
            Program.formFilial.MdiParent = Program.formMain;
            Program.formFilial.Show();
        }
        private void EditarSelecionado()
        {
            Program.formFilial = new FormFilial(itemSelecionado);
            Program.formFilial.MdiParent = Program.formMain;
            Program.formFilial.Show();
        }
        private void ExcluirSelecionado()
        {
            if (!Alerts.Ask("Confirma a exclusão do item selecionado?")) return;
            itemSelecionado.Delete();
            Alerts.Message("Item excluído!");
            btnAtualizar_Click(null, null);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            NovoItem();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarSelecionado();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirSelecionado();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarDados(txtFiltrar.Text);
        }
        private void AlternarBotoes()
        {
            btnFiltrar.Enabled = !string.IsNullOrWhiteSpace(txtFiltrar.Text);
            btnEditar.Enabled = dataGridView.SelectedRows.Count > 0;
            btnExcluir.Enabled = dataGridView.SelectedRows.Count > 0;
            btnSelecionar.Enabled = dataGridView.SelectedRows.Count > 0;
            if (this.returnClass != null)
            {
                btnSelecionar.Visible = true;
                btnSelecionar.Enabled = dataGridView.SelectedRows.Count > 0;
            }
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            AlternarBotoes();
            if (dataGridView.SelectedRows.Count > 0)
            {
                itemSelecionado = (Filial)listItems[dataGridView.SelectedRows[0].Index];
            }
        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CarregarDados(txtFiltrar.Text);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarSelecionado();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcluirSelecionado();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            returnClass.Return(itemSelecionado);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Alerts.Error("Funcionalidade ainda nao implementada");
        }

        public void Retornar()
        {
            btnAtualizar_Click(null, null);
        }
    }
}
