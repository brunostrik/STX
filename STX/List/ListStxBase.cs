using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace STX
{
    public partial class ListStxBase : Form, IListForm
    {
        public event EventHandler NovoPressed;
        public event EventHandler EditarPressed;
        public event EventHandler ExcluirPressed;
        public event EventHandler AtualizarPressed;
        public event EventHandler ImprimirPressed;
        public event EventHandler SelecionarPressed;
        public event EventHandler FiltrarPressed;
        public event EventHandler DataGridRowEnter;

        public ISelector ReturnClass { get; set; } = null;
        public string SearchProperty { get; set; } = "";

        public ListStxBase()
        {
            InitializeComponent();
            ReturnClass = null;
            AlternarBotoes();
        }

        public ListStxBase(ISelector returnSelector = null)
        {
            InitializeComponent();
            ReturnClass = returnSelector;
            AlternarBotoes();
        }

        public void CarregarGrid(List<object> dataList)
        {
            if (dataList == null || dataList.Count == 0)
            {
                dataGridView.DataSource = null;
                dataGridView.Refresh();
                return;
            }

            dataGridView.DataSource = dataList;
            //Identifica conforme os StxAttributes algumas propriedades específicas como label da coluna e visibilidade
            var props = dataList[0].GetType().GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                dataGridView.Columns[i].HeaderText = prop.GetCustomAttributesData().Where(item => item.AttributeType == typeof(Field)).FirstOrDefault().ConstructorArguments[1].Value.ToString();
                dataGridView.Columns[i].Visible = Convert.ToBoolean(prop.GetCustomAttributesData().Where(item => item.AttributeType == typeof(Field)).FirstOrDefault().ConstructorArguments[5].Value);
            }
            dataGridView.Refresh();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            NovoPressed(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarPressed(sender, e);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!Alerts.Ask("Confirma a exclusão do item selecionado?"))
            {
                return;
            }
            ExcluirPressed(sender, e);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarPressed(sender, e);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirPressed(sender, e);
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            SelecionarPressed(sender, e);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarPressed(sender, e);
        }

        private void txtFiltrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FiltrarPressed(sender, e);
            }
        }
        public void AlternarBotoes()
        {
            btnFiltrar.Enabled = !string.IsNullOrWhiteSpace(txtFiltrar.Text) && SearchProperty != "";
            btnEditar.Enabled = dataGridView.SelectedRows.Count > 0;
            btnExcluir.Enabled = dataGridView.SelectedRows.Count > 0;
            btnSelecionar.Enabled = dataGridView.SelectedRows.Count > 0;
            btnFiltrar.Visible = SearchProperty != "";
            txtFiltrar.Visible = SearchProperty != "";
            lblFiltrar.Visible = SearchProperty != "";
            btnSelecionar.Visible = true && ReturnClass != null;
            btnSelecionar.Enabled = dataGridView.SelectedRows.Count > 0 && ReturnClass != null;
        }


        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            AlternarBotoes();
            DataGridRowEnter(sender, e);
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].HeaderText == "Senha" && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
            else if ((dataGridView.Columns[e.ColumnIndex].HeaderText == "Valor" || dataGridView.Columns[e.ColumnIndex].HeaderText == "Preço") && e.Value != null)
            {
                //formatar como moeda
                e.Value = string.Format("{0:C}", e.Value);
            }
        }
        public void Retornar()
        {
            AtualizarPressed(null, null);
        }
    }
}
