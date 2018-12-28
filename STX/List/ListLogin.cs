using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace STX
{
    public partial class ListLogin : Form, IListForm
    {

        private ISelector returnClass;
        private List<Login> listItems;
        private Login itemSelecionado;

        public ListLogin(ISelector returnSelector = null)
        {
            InitializeComponent();
            returnClass = returnSelector;
            if (returnClass != null)
            {
                Text = Config.APP_NAME + " - Selecione um item";
            }
            else
            {
                Text = Config.APP_NAME;
            }
            btnAtualizar_Click(null, null);
        }

        private void CarregarDados(string filtro = "")
        {
            CriteriaBuilder cb = new CriteriaBuilder();
            cb.Add("usuario", filtro, MatchMode.Like);
            listItems = new Login().Select(cb);
            dataGridView.DataSource = listItems;
            dataGridView.Refresh();
            AlternarBotoes();
        }
        private void NovoItem()
        {
            //Program.formLogin = new FormLogin(new Login());
            //Program.formLogin.MdiParent = Program.formMain;
            //Program.formLogin.Show();
        }
        private void EditarSelecionado()
        {
            //Program.formLogin = new FormLogin(itemSelecionado);
            //Program.formLogin.MdiParent = Program.formMain;
            //Program.formLogin.Show();
        }
        private void ExcluirSelecionado()
        {
            if (!Alerts.Ask("Confirma a exclusão do item selecionado?"))
            {
                return;
            }

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
            txtFiltrar.Text = "";
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
            btnTrocaSenha.Enabled = dataGridView.SelectedRows.Count > 0;
            if (returnClass != null)
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
                itemSelecionado = (Login)listItems[dataGridView.SelectedRows[0].Index];
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

        private void btnTrocaSenha_Click(object sender, EventArgs e)
        {
            Program.formTrocaSenha = new FormTrocaSenha(itemSelecionado, false);
            Program.formTrocaSenha.ShowDialog();
        }
    }
}
