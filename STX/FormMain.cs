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
            Program.formLogin = new FormLogin();
            Program.formLogin.ShowDialog();
            if (Program.login == null)
            {
                Application.Exit();
            }
        }

        private void filiaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.listFilial = new ListFilial();
            Program.listFilial.MdiParent = Program.formMain;
            Program.listFilial.Show();
        }
    }
}
