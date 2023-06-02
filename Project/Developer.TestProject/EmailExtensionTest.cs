using Developer.ExtensionCore;
using Developer.ExtensionCore.Entities;
using System.Net.Mail;
using System.Text;

namespace Developer.TestProject
{
    [TestClass]
    public class EmailExtensionTest
    {
        [TestMethod]
        public async Task Test_SendMailAsync()
        {
            EmailSettings emailSettings = new()
            {
                //MailMessage
                Address = "email@provedor.com",
                DisplayName = "Developer.ExtensionCore - DisplyName",
                DisplayNameEncoding = Encoding.UTF8,
                ListTo = new List<string>() { "email@provedor.com" },
                ListCC = new List<string>() { "email@provedor.com" },
                ListAttachment = new List<Attachment>(),
                SubjectEncoding = Encoding.UTF8,
                Subject = "Developer.ExtensionCore - Title E-mail",
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                Body = @"Test <strong>e-mail</strong> body. 
                         by - Developer.ExtensionCore",
                Priority = MailPriority.High,

                //SmtpClient
                Host = "host",
                Port = 0,
                EnableSSL = true,
                UseDefaultCredentials = false,
                UserName = "email@provedor.com",
                UserPassword = "password",
            };

            KeyValuePair<bool, string> result = await EmailExtension.SendMailAsync(emailSettings);

            //Espera de um valor falso, pois não está preenchido corretamente as configurações.
            Assert.IsFalse(result.Key);
        }

    }
}
