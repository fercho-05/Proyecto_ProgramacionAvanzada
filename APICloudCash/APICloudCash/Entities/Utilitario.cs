using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace APICloudCash.Entities
{
    public class Utilitario
    {
        
        
        string correoUsuario = ConfigurationManager.AppSettings["CorreoUsuario"];
        string claveUsuario = ConfigurationManager.AppSettings["ClaveUsuario"];
        string servidorCorreo = ConfigurationManager.AppSettings["ServidorCorreo"];
        /*
        public void EnvioCorreos(string destino, string asunto, string contenido)
        {


            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(correoUsuario);
            mailMessage.To.Add(new MailAddress(destino));
            mailMessage.Subject = asunto;
            mailMessage.Body = contenido;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();// Servidor de correo
            smtpClient.Port = 587;
            smtpClient.Host = servidorCorreo;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(correoUsuario, claveUsuario);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(mailMessage);
        }*/
    }

}