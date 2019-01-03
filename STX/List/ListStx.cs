using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace STX
{
    public partial class ListStx<T> : Form, IListForm where T : IModel<T>
    {

        private ISelector returnClass;
        private string searchProperty;
        private List<T> listItems;
        private IModel<T> itemSelecionado;

        public ListStx(string searchProperty = "", ISelector returnSelector = null)
        {
            InitializeComponent();
            returnClass = returnSelector;
            this.searchProperty = searchProperty;
            if (returnClass != null)
            {
                Text = Config.APP_NAME + " - Selecione um " + Config.APP_NAME + " - " + ((Table)typeof(T).GetCustomAttribute(typeof(Table), false)).NomeSingular + ":";
            }
            else
            {
                //Procura a anotacao na entidade e assim constroi o text do form
                Text = Config.APP_NAME + " - " + Util.FirstCharToUpper(((Table)typeof(T).GetCustomAttribute(typeof(Table), false)).NomePlural);
            }
            AtualizarDados();
            dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
        }

        private void CarregarDados(string filtro = "")
        {
            CriteriaBuilder cb = null;
            if (filtro != "")
            {
                cb = new CriteriaBuilder();
                cb.Add(searchProperty, filtro, MatchMode.Like);
            }
            listItems = GenericController<T>.Select(cb);
            CarregarGrid(listItems);
            SelecaoGrid();
            AlternarBotoes();
        }

        private void CarregarGrid(List<T> dataList)
        {
            if (dataList.Count == 0)
            {
                return;
            }

            dataGridView.DataSource = dataList;
            //Identifica conforme os StxAttributes algumas propriedades específicas como label da coluna e visibilidade
            var props = typeof(T).GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                dataGridView.Columns[i].HeaderText = prop.GetCustomAttributesData().Where(item => item.AttributeType == typeof(Field)).FirstOrDefault().ConstructorArguments[1].Value.ToString();
                dataGridView.Columns[i].Visible = Convert.ToBoolean(prop.GetCustomAttributesData().Where(item => item.AttributeType == typeof(Field)).FirstOrDefault().ConstructorArguments[5].Value);
            }
            dataGridView.Refresh();
        }

        private void NovoItem()
        {
            T newItem = Activator.CreateInstance<T>();
            Program.OpenForm<T>((IModel<T>)newItem, this);
        }
        private void EditarSelecionado()
        {
            Program.OpenForm<T>(itemSelecionado, this);
        }
        private void ExcluirSelecionado()
        {
            if (!Alerts.Ask("Confirma a exclusão do item selecionado?"))
            {
                return;
            }

            if (itemSelecionado.Delete())
            {
                Alerts.Message("Item excluído!");
                AtualizarDados();
            }
            else
            {
                Alerts.Error("Falha ao excluir o item selecionado.");
            }
        }

        private void AtualizarDados()
        {
            txtFiltrar.Text = "";
            CarregarDados();
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
            AtualizarDados();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarDados(txtFiltrar.Text);
        }
        private void AlternarBotoes()
        {
            btnFiltrar.Enabled = !string.IsNullOrWhiteSpace(txtFiltrar.Text) && searchProperty != "";
            btnEditar.Enabled = dataGridView.SelectedRows.Count > 0;
            btnExcluir.Enabled = dataGridView.SelectedRows.Count > 0;
            btnSelecionar.Enabled = dataGridView.SelectedRows.Count > 0;
            btnFiltrar.Visible = searchProperty != "";
            txtFiltrar.Visible = searchProperty != "";
            lblFiltrar.Visible = searchProperty != "";
            btnSelecionar.Visible = true && returnClass != null;
            btnSelecionar.Enabled = dataGridView.SelectedRows.Count > 0 && returnClass != null;
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelecaoGrid();
        }

        private void SelecaoGrid()
        {
            AlternarBotoes();
            if (dataGridView.SelectedRows.Count > 0 && listItems.Count > 0)
            {
                itemSelecionado = (IModel<T>)listItems[dataGridView.SelectedRows[0].Index];
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
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Alerts.Error("Funcionalidade ainda nao implementada");
        }

        public void Retornar()
        {
            AtualizarDados();
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
    }
}
