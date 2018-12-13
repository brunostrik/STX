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
    public partial class FormFilial : Form
    {
        private Filial entity;
        IListForm listaRetorno;

        public FormFilial(Filial e, IListForm lf = null)
        {
            InitializeComponent();
            this.Text = Program.APP_NAME + " - " + "Filial";
            this.listaRetorno = lf;
            DefineEntidadeCampos(e);
        }

        private void DefineEntidadeCampos(Filial e)
        {
            this.entity = e;

            //Campos
            txtCodigo.Text = entity.id.ToString();
            txtNome.Text = entity.nome;
            cmbAtivo.SelectedIndex = (entity.ativo ? 0 : 1);
            btnExcluir.Enabled = entity.id != 0;
        }
        private bool ValidarMontarPreenchimento()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                Alerts.Alert("O preenchimento do campo é obrigatório: " + "Código");
                txtCodigo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                Alerts.Alert("O preenchimento do campo é obrigatório: " + "Nome");
                txtNome.Focus();
                return false;
            }
            if (cmbAtivo.SelectedIndex == 1)
            {
                if (!Alerts.Ask("Tem certeza que deseja definir este item como desativado?\nUm item desativado não aparecerá como disponível no sistema, embora continue existindo para consultas e relatórios antigos."))
                {
                    cmbAtivo.Focus();
                    return false;
                }              
            }
            //Montar entidade
            entity.id = Convert.ToInt32(txtCodigo.Text);
            entity.nome = txtNome.Text;
            entity.ativo = cmbAtivo.SelectedIndex == 0;
            return true;
        }

        private void Salvar()
        {
            if (entity.id == 0)
            {
                entity.Insert();
                Alerts.Message("Item adicionado!");
                if (listaRetorno != null)
                {
                    listaRetorno.Retornar();
                }
                this.Close();
            }
            else
            {
                entity.Update();
                Alerts.Message("Item atualizado!");
                if (listaRetorno != null)
                {
                    listaRetorno.Retornar();
                }
                this.Close();
            }
        }
        private void Excluir()
        {
            if (!Alerts.Ask("Confirma a exclusão do item selecionado?")) return;
            entity.Delete();
            Alerts.Message("Item excluído!");
            if (listaRetorno != null)
            {
                listaRetorno.Retornar();
            }
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarMontarPreenchimento()) return;
            Salvar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }
    }
}
