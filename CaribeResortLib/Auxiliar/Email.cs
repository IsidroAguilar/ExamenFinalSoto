using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CaribeResortLib.Auxiliar
{
    public class Email
    {

        
        public static bool EnviarEmail(string remitente, string destinatario, string contrasena, string asunto, string mensaje)
        {
            try
            {
                var mailRemitente = new MailAddress(remitente);
                var mailDestinatario = new MailAddress(destinatario);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(mailRemitente.Address, contrasena)
                };
                using (var message = new MailMessage(mailRemitente, mailDestinatario)
                {
                    Subject = asunto,
                    Body = mensaje,                   
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
