using System.Net;
using System.Net.Mail;

namespace CourseReportEmailer.Workers
{
    internal class EnrollmentDetailReportEmailSender
    {
        public void Send(string filename, string emailAddressTo, NetworkCredential? emailCredentials)
        {
            if (emailCredentials != null)
            {
                var client = new SmtpClient("smtp-mail.outlook.com");
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = emailCredentials;

                var msg = new MailMessage(emailCredentials.UserName, emailAddressTo);
                msg.Subject = "Enrollment Details Report";
                msg.IsBodyHtml = true;
                msg.Body = "Please find attached the enrollment report.";

                msg.Attachments.Add(new Attachment(filename));

                client.Send(msg);
            }
        }
    }
}
