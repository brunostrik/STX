using System;
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
            Text = Config.APP_NAME + " - " + "Filial";
            listaRetorno = lf;
            DefineEntidadeCampos(e);
        }

        private void DefineEntidadeCampos(Filial e)
        {
            entity = e;

            //Bindings de usabilidade
            if (entity.id == 0)
            {
                entity.ativo = true;
            }

            //Campos
            txtCodigo.Text = entity.id.ToString();
            txtNome.Text = entity.nome;
            cmbAtivo.SelectedIndex = entity.ativo ? 0 : 1;
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
            if (cmbAtivo.SelectedIndex == 0)
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
                if (entity.Insert())
                {
                    Alerts.Message("Item adicionado!");
                    if (listaRetorno != null)
                    {
                        listaRetorno.Retornar();
                    }
                    Close();
                }
                else
                {
                    Alerts.Error("Falha ao excluir este item.");
                }
            }
            else
            {
                if (entity.Update())
                {
                    Alerts.Message("Item atualizado!");
                    if (listaRetorno != null)
                    {
                        listaRetorno.Retornar();
                    }
                    Close();
                }
                else
                {
                    Alerts.Alert("Falha ao atualizar este item.");
                }
            }
        }
        private void Excluir()
        {
            if (!Alerts.Ask("Confirma a exclusão do item selecionado?"))
            {
                return;
            }

            if (entity.Delete())
            {
                Alerts.Message("Item excluído!");
                if (listaRetorno != null)
                {
                    listaRetorno.Retornar();
                }
                Close();
            }
            else
            {
                Alerts.Error("Falha ao excluir este item.");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarMontarPreenchimento())
            {
                Salvar();
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }
    }
}
