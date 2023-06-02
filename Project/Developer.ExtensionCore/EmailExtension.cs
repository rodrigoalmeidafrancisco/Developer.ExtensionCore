using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Developer.ExtensionCore.Entities;

namespace Developer.ExtensionCore
{
    public static class EmailExtension
    {
        public static async Task<KeyValuePair<bool, string>> SendMailAsync(this EmailSettings emailSettings)
        {
            bool result = false;
            string message = string.Empty;

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    //De
                    mail.From = new MailAddress(emailSettings.Address, emailSettings.DisplayName, emailSettings.DisplayNameEncoding);

                    //Para
                    if (emailSettings.ListTo != null && emailSettings.ListTo.Any())
                    {
                        emailSettings.ListTo.ForEach(item => mail.To.Add(item.Trim()));
                    }

                    //Para CC
                    if (emailSettings.ListCC != null && emailSettings.ListCC.Any())
                    {
                        emailSettings.ListCC.ForEach(item => mail.CC.Add(item.Trim()));
                    }

                    //Arquivos anexos ao e-mail
                    if (emailSettings.ListAttachment != null && emailSettings.ListAttachment.Any())
                    {
                        emailSettings.ListAttachment.ForEach(item => mail.Attachments.Add(item));
                    }

                    //Título
                    mail.SubjectEncoding = emailSettings.SubjectEncoding;
                    mail.Subject = emailSettings.Subject;

                    //Corpo do E-mail
                    mail.IsBodyHtml = emailSettings.IsBodyHtml;
                    mail.BodyEncoding = emailSettings.BodyEncoding;
                    mail.Body = emailSettings.Body;

                    //Prioridade
                    mail.Priority = emailSettings.Priority;

                    using (SmtpClient smtpClient = new SmtpClient(emailSettings.Host, emailSettings.Port))
                    {
                        smtpClient.EnableSsl = emailSettings.EnableSSL;
                        smtpClient.UseDefaultCredentials = emailSettings.UseDefaultCredentials;
                        smtpClient.Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.UserPassword);
                        await smtpClient.SendMailAsync(mail);
                    }

                    result = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }

            return new KeyValuePair<bool, string>(result, message);
        }


    }
}
