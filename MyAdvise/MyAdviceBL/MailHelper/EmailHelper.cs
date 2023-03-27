using DataAccessLayer.Models.Models;
using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MyAdviceWebApi.MailHelper
{
    public class EmailHelper
    {
        private static readonly string Asunto = "Thanks for logging into MyAdvice";
        private static readonly string Mail = "example@mail.com";
        private static readonly string Password = "ExamplePassword";

        public static void SendEmail(UserVM userVM)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(userVM.Email));
                message.From = new MailAddress(Mail, "Example");
                message.Subject = Asunto;
                message.Body = GenerateEmail();
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential(Mail, Password);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }

        private static string GenerateEmail()
        {
            var correo =
                "<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">"
        + "<tr>"
            + "<td>"
                + "<table align=\"center\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\">"
                    + "<tr>"
                        + "<td align=\"center\" bgcolor=\"#fff\" style=\"padding: 40px 0 30px 0;\">"
                            + "<img src=\"https://cdn.discordapp.com/attachments/701005468541124608/714877740435636284/unknown.png\" alt=\"Creating Email Magic\" width=\"300\" height=\"230\" style=\"display: block;\" />"
                        + "</td>"
                    + "</tr>"
                    + "<tr>"
                        + "<td bgcolor=\"#ffffff\" style=\"padding: 40px 30px 40px 30px;\">"
                            + "<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">"
                                + "<tr>"
                                    + "<td>"
                                        + "¡Bienvenido!"
                                        + "<br>"
                                        + "¡Ya formas parte de  MyAdvice!"
                                    + "</td>"
                                + "</tr>"
                                + "<tr>"
                                    + "<td style=\"padding: 20px 0 30px 0;\">"
                                        + "Muchisimas gracias por registrarte. Queremos que tu guia online se convierta en una experiencia sensacional."
                                    + "</td>"
                                + "</tr>"
                                + "<tr>"
                                    + "<td style=\"font-size: 12px; color: lightslategray;\">"
                                        + "¡Un segundo! Tenemos que contarte una cosa... Si quieres recibir mas informacion antes que nadie, no olvides mandarnos un correo a la siguiente direccion: information@myadvice.com"
                                    + "</td>"
                                + "</tr>"
                            + "</table>"
                        + "</td>"
                    + "</tr>"
                    + "<tr>"
                        + "<td style=\"padding: 30px 30px 30px 30px; font-size: 12px;\">"
                            + "Tenga en cuenta que este correo ha sido auto generado, por lo tanto no intente responder a este correo electronico dado que su correo no va a ser revisado, sobre cualquier duda o pregunta que tenga puede hacernosla en la siguiente direccion de correo electrónico: <a href=\"mailto:soporte@myadvice.com\">soporte@myadvice.com</a>"
                        + "</td>"
                    + "</tr>"
                + "</table>"
            + "</td>"
        + "</tr>"
    + "</table>";

            return correo;

        }
    }
}
