using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Developer.ExtensionCore
{
    public static class EmailExtension
    {
        public static async Task<KeyValuePair<bool, string>> SendMailAsync(EmailSettings emailSettings)
        {
            bool result = false;
            string message = string.Empty;

            try
            {
                using (SmtpClient smtpClient = new SmtpClient(emailSettings.Host, emailSettings.Port))
                {
                    smtpClient.Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.Password);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.Subject = emailSettings.Title;
                        mail.From = new MailAddress(emailSettings.FromAddress, emailSettings.FromDisplayName, emailSettings.FromDisplayNameEncoding);

                        mail.IsBodyHtml = emailSettings.IsBodyHtml;
                        mail.Body = emailSettings.Body;
                        mail.BodyEncoding = emailSettings.BodyEncoding;

                        if (emailSettings.ListTo != null && emailSettings.ListTo.Any())
                        {
                            foreach (var item in emailSettings.ListTo)
                            {
                                mail.To.Add(item.Trim());
                            }
                        }

                        await smtpClient.SendMailAsync(mail);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }

            return new KeyValuePair<bool, string>(result, message);
        }

        public class EmailSettings
        {
            public EmailSettings()
            {
                FromDisplayNameEncoding = Encoding.UTF8;
                BodyEncoding = Encoding.UTF8;
            }

            public EmailSettings(Encoding fromDisplayNameEncoding, Encoding bodyEncoding)
            {
                FromDisplayNameEncoding = fromDisplayNameEncoding;
                BodyEncoding = bodyEncoding;
            }

            public EmailSettings(string host, int port, string userName, string password, string title, string fromAddress, string fromDisplayName,
                Encoding fromDisplayNameEncoding, bool isBodyHtml, string body, Encoding bodyEncoding, List<string> listTo)
            {
                Host = host;
                Port = port;
                UserName = userName;
                Password = password;
                Title = title;
                FromAddress = fromAddress;
                FromDisplayName = fromDisplayName;
                FromDisplayNameEncoding = fromDisplayNameEncoding;
                IsBodyHtml = isBodyHtml;
                Body = body;
                BodyEncoding = bodyEncoding;
                ListTo = listTo == null ? new List<string>() : listTo;
            }

            public string Host { get; set; }
            public int Port { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Title { get; set; }
            public string FromAddress { get; set; }
            public string FromDisplayName { get; set; }
            public Encoding FromDisplayNameEncoding { get; set; }
            public bool IsBodyHtml { get; set; }
            public string Body { get; set; }
            public Encoding BodyEncoding { get; set; }
            public List<string> ListTo { get; set; }
        }

    }
}
