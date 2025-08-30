using Portafolio.Models;
using System.Net;
using System.Net.Mail;

namespace Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task Send(ContactoViewModel contact);
    }

    public class ServicioEmailGmail : IServicioEmail
    {
        private readonly IConfiguration _configuration;

        public ServicioEmailGmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Send(ContactoViewModel contact)
        {
            var emailEmisor = _configuration.GetValue<string>("CONFIGURATIONS_EMAIL:EMAIL");
            var password = _configuration.GetValue<string>("CONFIGURATIONS_EMAIL:PASSWORD");

            var host = _configuration.GetValue<string>("CONFIGURATIONS_EMAIL:HOST");
            var puerto = _configuration.GetValue<int>("CONFIGURATIONS_EMAIL:PORT");

            var smtpClient = new SmtpClient(host, puerto);
            smtpClient.EnableSsl = true;//Conexion ssl segura
            smtpClient.UseDefaultCredentials = false;//vamos a pasar las credenciales por el emailemisor y password

            smtpClient.Credentials = new NetworkCredential(emailEmisor, password);

            if (emailEmisor is not null)
            {
                var message = new MailMessage(emailEmisor, emailEmisor, $"El cliente {contact.Name} ({contact.Email} quiere contactarte)", contact.Message);

                await smtpClient.SendMailAsync(message);
            }

        }

    }
}
