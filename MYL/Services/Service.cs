using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace MYL.Services
{
    public class Service
    {
        public void SendEmail(string email)
        {
            try
            {
                var from = new MailAddress("test76562@gmail.com", "Мой сайт");
                var to = new MailAddress(email);
                MailMessage message = new MailMessage(from,to);
                message.Subject = "Служба поддержки сайта MYL";
                message.Body = "Ваш запрос принят в обработку, служба поддержки ответит в течении 3 рабочих дней";
                message.IsBodyHtml = true;
                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Credentials = new NetworkCredential("test76562@gmail.com", "ooinjmkywbfwbbvc");
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Send(message);
                }
                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
