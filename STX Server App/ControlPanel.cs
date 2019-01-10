using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace STX_Server_App
{
    public partial class ControlPanel : Form
    {

        private System.Threading.Timer Schedular;

        public ControlPanel()
        {
            InitializeComponent();
            WriteToFile("STX Daemon Iniciado {0}");
            ScheduleService();
        }

        private void ControlPanel_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja finalizar o sistema mantenedor dos serviços STX?\r\nVocê pode também minimizar e os serviços continuam funcionando normalmente em segundo plano.", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void Executar()
        {
            try
            {
                string CmdString = "SELECT l.id as idlembrete, l.titulo as assunto, l.mensagem as corpo, r.email as remetente, d.email as destinatario " +
                                    "FROM lembrete l " +
                                    "JOIN login r ON l.idloginremetente = r.id " +
                                    "JOIN lembretedestinatario ld ON ld.idlembrete = l.id " +
                                    "JOIN login d ON ld.idlogindestinatario = d.id " +
                                    //"WHERE l.enviada = 0 " +
                                    //"AND DATE(l.datahoraenvio) <= DATE(NOW()) " + //comentar esta linha para forceps em todos
                                    "ORDER BY l.id";
                connection = getConnection();
                connection.Open();
                MySqlDataReader rs = new MySqlCommand(CmdString, connection).ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rs);
                List<int> idLembretesEnviadosRaw = new List<int>();
                if (dt.Rows.Count == 0)
                {
                    WriteToFile("Não há mensagens pendentes");
                    return;
                }
                foreach (DataRow dr in dt.Rows)
                {

                    SendMail(dr["remetente"].ToString(), dr["destinatario"].ToString(), dr["assunto"].ToString(), dr["corpo"].ToString());
                    idLembretesEnviadosRaw.Add((int)dr["idlembrete"]);
                }
                rs.Close();
                //registra que foi enviada a mensagem
                CmdString = "UPDATE lembrete SET enviada = 1 WHERE id IN (";
                foreach (int n in idLembretesEnviadosRaw.Distinct())
                {
                    CmdString += n + ", ";
                }
                CmdString += "-1)"; //coloca essa gambi aqui só pra nao bugar na ultima virgula perdida
                new MySqlCommand(CmdString, connection).ExecuteNonQuery();
                WriteToFile("Foram sincronizadas " + dt.Rows.Count + " mensagens.");
                connection.Close();
            }
            catch (Exception x)
            {
                WriteToFile("Erro STX Daemon - Sincronização de mensagens: " + x.Message);
                throw x;
            }
        }
        private void SchedularCallback(object e)
        {
            WriteToFile("STX Log: {0}");
            Executar(); //FAZ AS COISAS
            ScheduleService();
        }

        public void ScheduleService()
        {
            try
            {
                Schedular = new System.Threading.Timer(new TimerCallback(SchedularCallback));

                //Set the Default Time.
                DateTime scheduledTime = DateTime.MinValue;

                //Get the Interval in Minutes from AppSettings.
                int intervalMinutes = 1;

                //Set the Scheduled Time by adding the Interval to Current Time.
                scheduledTime = DateTime.Now.AddMinutes(intervalMinutes);
                if (DateTime.Now > scheduledTime)
                {
                    //If Scheduled Time is passed set Schedule for the next Interval.
                    scheduledTime = scheduledTime.AddMinutes(intervalMinutes);
                }


                TimeSpan timeSpan = scheduledTime.Subtract(DateTime.Now);
                string schedule = string.Format("{0} dia(s) {1} hora(s) {2} minuto(s) {3} segundo(s)", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

                WriteToFile("Daemon STX definido para: " + schedule + " {0}");

                //Get the difference in Minutes between the Scheduled and Current Time.
                int dueTime = Convert.ToInt32(timeSpan.TotalMilliseconds);

                //Change the Timer's Due Time.
                Schedular.Change(dueTime, Timeout.Infinite);
            }
            catch (Exception ex)
            {
                WriteToFile("Erro no STX Daemon: {0} " + ex.Message + ex.StackTrace);

                //Stop the Windows Service.
                Schedular.Dispose();
            }
        }

        public void WriteToFile(string text)
        {
            string appendText = string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            txtLog.Text = appendText + "\r\n" + txtLog.Text;
            string path = "C:\\ServiceLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")));
                writer.Close();
            }
            
        }

        private static MySqlConnection connection;

        private string GetConnectionString()
        {
            return "Server=127.0.0.1;Database=stx;Uid=root;Pwd=strik;";
        }

        public MySqlConnection getConnection()
        {
            connection = new MySqlConnection(GetConnectionString());
            return connection;
        }
        private void SendMail(string mailFrom, string mailTo, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("ti@strikturismo.com.br", "Sistema STX");
            // The important part -- configuring the SMTP client
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
            smtp.EnableSsl = false;// true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
            smtp.UseDefaultCredentials = false; // [3] Changed this
            smtp.Credentials = new NetworkCredential("ti@strikturismo.com.br", "strikturismo2002");  // [4] Added this. Note, first parameter is NOT string.
            smtp.Host = "mail.strikturismo.com.br";
            //recipient address
            mail.To.Add(new MailAddress(mailTo));
            mail.ReplyTo = new MailAddress(mailFrom);
            //Formatted mail body
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = message;
            smtp.Send(mail);
        }
    }
}
