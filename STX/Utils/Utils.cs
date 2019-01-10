using STX.Properties;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

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
        public static void SendMail(string mailFrom, string mailTo, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("ti@strikturismo.com.br", Config.APP_NAME);
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
