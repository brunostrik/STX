using System;
using System.Windows.Forms;

namespace STX
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Visible = false;
            Program.formLoad = new FormLoad();
            Program.formLoad.ShowDialog();
            Program.formLogar = new FormLogar();
            Program.formLogar.ShowDialog();
            if (Program.login == null)
            {
                Application.Exit();
            }
            ConfigurarPermissoes();
            lblUser.Text = "Usuário: " + Program.login.usuario;
        }

        private void ConfigurarPermissoes()
        {
            ConfigMenu();
        }

        private void filiaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.OpenList<Filial>("nome");
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.OpenList<Login>("usuario");
        }

        private void lembretesAgendadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.OpenList<Lembrete>("");
        }

        private void sincronizarLembretesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Alerts.Alert(new LembreteControl().Sincronizar());
            }
            catch (Exception x)
            {
                Alerts.Error("Erro ao sincronizar.\r\n" + x.Message);
            }
        }

        private void ConfigMenu() //OCULTAR AQUI DO MENU AS FUNCIONALIDADES AINDA NAO INSTALADAS PARA CONSTRUIR RELEASES PARCIAIS
        {
            string[] manter = { "Ferramentas", "Vendas" };
            foreach (ToolStripMenuItem menu in menuStrip.Items)
            {
                menu.Visible = false;
                foreach(string m in manter)
                {
                    if (m.ToUpper() == menu.Text.ToUpper())
                    {
                        menu.Visible = true;
                    }
                }
                
            }
        }

        private void passageirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.OpenList<Passageiro>("nome");
        }
    }
}
