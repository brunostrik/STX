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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.Visible = false;
            Program.formLoad = new FormLoad();
            Program.formLoad.ShowDialog();
            Program.formLogar = new FormLogar();
            Program.formLogar.ShowDialog();
            if (Program.login == null)
            {
                Application.Exit();
            }
            ConfigurarPermissoes();
        }

        private void ConfigurarPermissoes()
        {

        }

        private void filiaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.OpenList<Filial>("nome");
        }
        
        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.OpenList<Login>("usuario");
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStx<Filial> form = new FormStx<Filial>(new Filial());
            form.MdiParent = this;
            form.Show();
        }
    }
}
