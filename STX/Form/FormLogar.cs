using System;
using System.Windows.Forms;

namespace STX
{
    public partial class FormLogar : Form
    {
        public FormLogar()
        {
            InitializeComponent();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(null, null);
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Alerts.Alert("Preencha o usuário.");
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                Alerts.Alert("Preencha a senha.");
                txtSenha.Focus();
                return;
            }
            Program.login = Login.Validate(txtUsuario.Text, txtSenha.Text);
            if (Program.login.id == 0)
            {
                Alerts.Alert("Usuário e/ou senha inválidos");
                return;
            }
            Logs.Log("Login do usuário " + Program.login.usuario);
            if (Program.login.trocar == 1)
            {
                Alerts.Message("Atenção: é necessário que você troque sua senha. Realize a troca e acesse novamente");
                txtSenha.Text = "";
                txtSenha.Focus();
                Program.formTrocaSenha = new FormTrocaSenha(Program.login, false);
                Program.formTrocaSenha.ShowDialog();
                return;
            }
            Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Activated(object sender, EventArgs e)
        {
            if (Config.DEBUG_MODE)
            {
                txtUsuario.Text = "teste";
                txtSenha.Text = "123";
                btnEntrar_Click(null, null);
            }
        }
    }
}
