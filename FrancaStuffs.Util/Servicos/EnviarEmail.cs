
using System;
using System.Net;
using System.Net.Mail;

namespace FrancaStuffs.Util.Servicos
{
    public class EnviarEmail
    {
        EmailConfig conf;
        public EnviarEmail(EmailConfig conf) => this.conf = conf;

        /// <summary>
        /// Envia um email
        /// </summary>
        /// <param name="email">dados do destinatário</param>
        /// <returns>Retorna um boleado baseado no envio</returns>
        public bool Enviar(EmailData email)
        {
            try
            {
                SmtpClient client = new SmtpClient(conf.Domain) { Port = 25 };
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(conf.Username, conf.Password);
                client.EnableSsl = conf.EnableSsl;
                if (conf.Port > 0) client.Port = conf.Port;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(conf.FromEmail),
                    Body = email.Body,
                    Subject = email.Subject,
                    IsBodyHtml = true

                };
                mailMessage.To.Add(email.To);
                if (email.CCo != null)
                    mailMessage.CC.Add(email.CCo);
                
                if (email.Files != null)
                    foreach (var item in email.Files)
                    {
                        var arquivo = new System.IO.FileInfo(item);
                        if (arquivo.Exists)
                        {
                            System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType
                            {
                                MediaType = System.Net.Mime.MediaTypeNames.Application.Octet,
                                Name = arquivo.Name
                            };
                            mailMessage.Attachments.Add(new Attachment(arquivo.FullName, contentType));
                        }
                    }

                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
    }

    /// <summary>
    /// Configurações do servidor para enviar o email
    /// </summary>
    public class EmailConfig
    {
        public String Domain { get; set; }
        public int Port { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String FromEmail { get; set; }
        public bool EnableSsl { get; set; }

    }

    /// <summary>
    /// Dados para postar o email
    /// </summary>
    public class EmailData
    {
        public String To { get; set; }
        public String Co { get; set; }
        public String CCo { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public string[] Files { get; set; }

    }
}