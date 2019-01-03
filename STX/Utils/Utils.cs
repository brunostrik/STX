using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using STX.Properties;
using System.Collections.Generic;

namespace STX
{
    public static class Util
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
        public static void SendMail(string mailFrom, List<string> mailTo, string subject, string message)
        {            
            //Config do server
            SmtpClient smtp = new SmtpClient();
            smtp.Port = Settings.Default.StxMailPort; 
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Settings.Default.StxMailUser, Settings.Default.StxMailPassword);
            smtp.Host = Settings.Default.StxMailServer;
            //Monta o email
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(Settings.Default.StxMailUser, "STX - " + mailFrom);
            foreach (string m in mailTo)
            {
                mail.To.Add(new MailAddress(m));
            }         
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = message;
            mail.ReplyTo = new MailAddress(mailFrom);
            smtp.Send(mail);
        }
    }
}
