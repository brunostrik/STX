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
    public partial class FormTrocaSenha : Form
    {
        public FormTrocaSenha()
        {
            InitializeComponent();
        }
        public FormTrocaSenha(Login login, bool pedirSenha = true)
        {
            InitializeComponent();
            txtUsuario.Text = login.usuario;
            if (!pedirSenha)
            {
                txtSenhaAtual.Text = login.senha;
                txtSenhaAtual.Enabled = false;
            }
        }

        private void txtSenha2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar_Click(null, null);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSenhaAtual.Text))
            {
                Alerts.Alert("Preencha sua senha atual");
                txtSenhaAtual.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSenha1.Text))
            {
                Alerts.Alert("Preencha a sua nova senha");
                txtSenha1.Focus();
                return;
            }
            if (txtSenha1.Text != txtSenha2.Text)
            {
                Alerts.Alert("A sua nova senha e a confirmação precisam ser iguais");
                txtSenha2.Focus();
                return;
            }
            Program.login.senha = txtSenha1.Text;
            Program.login.trocar = 0;
            try
            {
                Program.login.Update();
                Logs.Log("Trocado a senha do usuário " + Program.login.usuario);
                Alerts.Message("Sua senha foi alterada com sucesso!");
                this.Close();
            }catch (Exception x)
            {
                Alerts.Error("Erro ao realizar esta operação\rMensagem de erro do sistema: " + x.Message);
            }

        }
    }
}
