using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace STX
{
    public class ListLembrete : ListStxBase
    {

        private Lembrete itemSelecionado;
        private List<Lembrete> listItems;
        private ToolStripComboBox cmbFiltrar;

        public ListLembrete(ISelector returnSelector) : base(returnSelector)
        {
            InitializeComponent();
            //Selecionar apenas lembretes oriundos do usuario atual, ordenados pela data em que serao enviados
            btnEditar.Visible = false;
            lblFiltrar.Visible = false;
            txtFiltrar.Visible = false;
            btnFiltrar.Visible = false;            
            cmbFiltrar = new ToolStripComboBox();
            cmbFiltrar.Items.Add("Não");
            cmbFiltrar.Items.Add("Sim");
            cmbFiltrar.Alignment = ToolStripItemAlignment.Right;
            cmbFiltrar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltrar.SelectedItem = "Não";
            cmbFiltrar.SelectedIndexChanged += CmbFiltrar_SelectedIndexChanged;
            toolStrip.Items.Add(cmbFiltrar);
            ToolStripLabel lblComboFiltro = new ToolStripLabel("Mostrar já enviados?");
            lblComboFiltro.Alignment = ToolStripItemAlignment.Right;
            toolStrip.Items.Add(lblComboFiltro);
            if (ReturnClass != null)
            {
                Text = Config.APP_NAME + " - Selecione um Lembrete:";
            }
            else
            {
                //Procura a anotacao na entidade e assim constroi o text do form
                Text = Config.APP_NAME + " - Lembretes";
            }
            CarregarDados();
        }

        private void CmbFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // ListLembrete
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            ClientSize = new System.Drawing.Size(800, 450);
            Name = "ListLembrete";
            NovoPressed += new System.EventHandler(ListLembrete_NovoPressed);
            ExcluirPressed += new System.EventHandler(ListLembrete_ExcluirPressed);
            AtualizarPressed += new System.EventHandler(ListLembrete_AtualizarPressed);
            DataGridRowEnter += new System.EventHandler(ListLembrete_DataGridRowEnter);
            ResumeLayout(false);
            PerformLayout();

        }

        private void ListLembrete_AtualizarPressed(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            CriteriaBuilder cb = new CriteriaBuilder();
            cb.AddWhere("enviada", cmbFiltrar.SelectedIndex, MatchMode.Equals);
            cb.AddWhere("idloginremetente", Program.login.id, MatchMode.Equals,CriterionRelation.And);
            cb.AddOrderBy("datahoraenvio", Ordenation.Asc);
            listItems = GenericController<Lembrete>.Select(cb);
            if (listItems != null)
            {
                CarregarGrid(listItems.Cast<object>().ToList());
            }
            else
            {
                CarregarGrid(null);
            }
            SelecaoGrid();
        }

        private void ListLembrete_ExcluirPressed(object sender, EventArgs e)
        {
            if (itemSelecionado.Delete())
            {
                Alerts.Message("Item excluído!");
                CarregarDados();
            }
            else
            {
                Alerts.Error("Falha ao excluir o item selecionado.");
            }
        }

        private void ListLembrete_NovoPressed(object sender, EventArgs e)
        {
            Lembrete newItem = new Lembrete();
            Program.OpenForm<Lembrete>(newItem, this);
        }

        private void ListLembrete_DataGridRowEnter(object sender, EventArgs e)
        {
            SelecaoGrid();
        }
        private void SelecaoGrid()
        {
            AlternarBotoes();
            if (dataGridView.SelectedRows.Count > 0 && listItems.Count > 0)
            {
                itemSelecionado = listItems[dataGridView.SelectedRows[0].Index];

            }
        }
    }
}
