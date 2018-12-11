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
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ConfigureDatabaseSystem();
        }
        private bool ConfigureDatabaseSystem()
        {
            switch (DBConfig.TestDatabaseConnection())
            {
                case 0: //tudo certo
                    return true;
                case 1: //sem arquivo de configuração
                    if (Alerts.Ask("O sistema não encontrou o arquivo de configuração.\rDeseja selecionar o arquivo agora?"))
                    {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.DefaultExt = "cfg";
                        ofd.Filter = "Arquivo de configuração (*.cfg)|*.cfg";
                        ofd.Multiselect = false;
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            DBConfig.SaveConfigFile(ofd.FileName);
                            return ConfigureDatabaseSystem();
                        }
                        else
                        {
                            return ConfigureDatabaseSystem();
                        }
                    }
                    else
                    {
                        Application.Exit();
                        return false;
                    }

                case 2: //rede cagada
                    Alerts.Error("Não foi possível conectar ao servidor de banco de dados. Provavelmente há um problema de conexão de rede/internet.\rVerifique sua conexão de internet, se estiver funcionando entre em contato com a " + Program.EMPRESA_MANTENEDORA + " pelo telefone " + Program.TELEFONE_SUPORTE);
                    Application.Exit();
                    return false;
                default:
                    Application.Exit();
                    return false;
            }
        }
    }
}
