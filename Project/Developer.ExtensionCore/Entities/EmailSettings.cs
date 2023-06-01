using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Developer.ExtensionCore.Entities
{
    public class EmailSettings
    {
        public EmailSettings()
        {
            #region MailMessage

            Address = "";
            DisplayName = "";
            DisplayNameEncoding = Encoding.Default;
            ListTo = new List<string>();
            ListCC = new List<string>();
            ListAttachment = new List<Attachment>();
            SubjectEncoding = Encoding.Default;
            Subject = "";
            IsBodyHtml = true;
            BodyEncoding = Encoding.Default;
            Body = "";
            Priority = MailPriority.Normal;

            #endregion MailMessage

            #region SmtpClient

            Host = "";
            Port = 0;
            EnableSSL = true;
            UseDefaultCredentials = false;
            UserName = "";
            UserPassword = "";

            #endregion SmtpClient
        }

        #region MailMessage

        public string Address { get; set; }
        public string DisplayName { get; set; }
        public Encoding DisplayNameEncoding { get; set; }
        public List<string> ListTo { get; set; }
        public List<string> ListCC { get; set; }
        public List<Attachment> ListAttachment { get; set; }
        public Encoding SubjectEncoding { get; set; }
        public string Subject { get; set; }
        public bool IsBodyHtml { get; set; }
        public Encoding BodyEncoding { get; set; }
        public string Body { get; set; }
        public MailPriority Priority { get; set; }

        #endregion MailMessage

        #region SmtpClient

        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        #endregion SmtpClient

    }
}
