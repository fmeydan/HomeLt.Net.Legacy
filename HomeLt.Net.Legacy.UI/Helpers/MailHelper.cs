using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;



namespace HomeLt.Net.Legacy.UI.Helpers
{
    public class MailHelper:IDisposable
    {
        private bool disposedValue;

        //public static bool SendMail(MailModel model)
        //{
        //    return SendMail(from: "iletisim@fitkutu.com", to: "iletisim@fitkutu.com", body: "İsimi " + model.firstname + " ve mail adresi " + model.Mail + " olan kullanıcıdan gelen mesaj: " + model.Message, subject: model.Subject, owner: model.Mail);
        //}

        public  bool SendMail(string from, string to, string body, string subject, string owner)
        {
            try
            {
                using (MailMessage mail = new MailMessage(from, to))
                {
                    using (SmtpClient client = new SmtpClient())
                    {
                        var senderEmail = new MailAddress(from, owner);
                        var receiverEmail = new MailAddress(to, "Fitkutu İletişim");
                        mail.Subject = subject;
                        mail.IsBodyHtml = true;
                        // mail.AlternateViews.Add(body as AlternateView);
                        mail.Body = body;
                        mail.Sender = senderEmail;
                        System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient();
                        //  SMTP.Host = "smtp.yandex.com.tr";
                        SMTP.Host = "smtp.yandex.com.tr";
                        SMTP.Port = 587;
                        SMTP.EnableSsl = true;

                        SMTP.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network; SMTP.UseDefaultCredentials = true;
                        SMTP.Credentials = new System.Net.NetworkCredential(from, "318881/Fuat");

                        SMTP.Send(mail);

                    }
                }

            }
            catch (Exception e)
            {

                return false;
            }
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MailHelper()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}