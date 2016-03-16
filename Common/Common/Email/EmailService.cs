using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Common.Email
{
    /*
     * Requires entry in Config File
     * Such as:
<configuration>
  <system.net>
    <mailSettings>
      <smtp from="jason.mistro@hotmail.com">
        <network defaultCredentials="true" />        
      </smtp>
    </mailSettings>
  </system.net>
</configuration>
     */
    public class EmailService 
    {
        public static void SendEmail(string recips, string subject, string bodyText, string attachmentpath = null)
        {
            MailMessage message = new MailMessage();

            if (!String.IsNullOrEmpty(recips))
            {
                string[] ToList = recips.Split(new char[] { ',', ';' });
                if (ToList != null && ToList.Count() > 0)
                {
                    foreach (string sTo in ToList)
                    {
                        message.To.Add(sTo.Trim());
                    }
                    message.Subject = subject;
                    message.Body = bodyText;

                    if (!string.IsNullOrEmpty(attachmentpath))
                    {
                        message.Attachments.Add(new Attachment(attachmentpath));
                    }

                    SmtpClient client = new SmtpClient();
                    client.Send(message);
                }
                else
                {
                    throw new Exception("Invalid Email Recipient List: " + recips);
                }
            }
        }

        public static void SendEmail(string recips, string subject, string bodyText, bool isHtml,  string attachmentpath = null)
        {
            MailMessage message = new MailMessage();

            if (!String.IsNullOrEmpty(recips))
            {
                string[] ToList = recips.Split(new char[] { ',', ';' });
                if (ToList != null && ToList.Count() > 0)
                {
                    foreach (string sTo in ToList)
                    {
                        message.To.Add(sTo.Trim());
                    }
                    message.Subject = subject;
                    message.Body = bodyText;
                    message.IsBodyHtml = isHtml;

                    if (!string.IsNullOrEmpty(attachmentpath))
                    {
                        message.Attachments.Add(new Attachment(attachmentpath));
                    }

                    SmtpClient client = new SmtpClient();
                    client.Send(message);
                }
                else
                {
                    throw new Exception("Invalid Email Recipient List: " + recips);
                }
            }
        }

        public static void SendEmailWithAttachments(string from, string recips, string subject, string bodyText, bool isBodyHtml, IEnumerable<string> attachmentPaths)
        {

            MailMessage message = new MailMessage();

            if (!String.IsNullOrEmpty(recips))
            {
                string[] ToList = recips.Split(new char[] { ',', ';' });
                if (ToList != null && ToList.Count() > 0)
                {
                    foreach (string sTo in ToList)
                    {
                        message.To.Add(sTo.Trim());
                    }
                    message.From = new MailAddress(from);
                    message.Subject = subject;
                    message.Body = bodyText;
                    message.IsBodyHtml = isBodyHtml;

                    if (attachmentPaths.Any())
                    {
                        foreach (var path in attachmentPaths)
                        {
                            message.Attachments.Add(new Attachment(path));
                        }

                    }

                    SmtpClient client = new SmtpClient();
                    client.Send(message);
                }
                else
                {
                    throw new Exception("Invalid Email Recipient List: " + recips);
                }
            }
        }

        public static void SendEmailWithAttachments(string from, string recips, string subject, string bodyText, IEnumerable<string> attachmentPaths)
        {

            MailMessage message = new MailMessage();

            if (!String.IsNullOrEmpty(recips))
            {
                string[] ToList = recips.Split(new char[] { ',', ';' });
                if (ToList != null && ToList.Count() > 0)
                {
                    foreach (string sTo in ToList)
                    {
                        message.To.Add(sTo.Trim());
                    }
                    message.From = new MailAddress(from);                  
                    message.Subject = subject;
                    message.Body = bodyText;

                    if (attachmentPaths.Any())
                    {
                        foreach (var path in attachmentPaths)
                        {
                            message.Attachments.Add(new Attachment(path));
                        }

                    }

                    SmtpClient client = new SmtpClient();
                    client.Send(message);
                }
                else
                {
                    throw new Exception("Invalid Email Recipient List: " + recips);
                }
            }
        }

        public static void SendEmail(string from, IEnumerable<string> recips, IEnumerable<string> BccList, string subject, string bodyText, IEnumerable<string> attachmentPaths)
        {

            using (MailMessage message = new MailMessage())
            {
                //MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                if (recips != null && recips.Any())
                {
                    if (!String.IsNullOrEmpty(from))
                    {
                        message.From = new MailAddress(from);
                    }
                    if (recips != null)
                    {
                        foreach (var to in recips)
                        {
                            message.To.Add(to);
                        }
                    }
                    if (BccList != null)
                    {
                        foreach (var blind in BccList)
                        {
                            message.Bcc.Add(blind);
                        }
                    }
                    message.Subject = subject;
                    message.Body = bodyText;

                    if (attachmentPaths != null && attachmentPaths.Any())
                    {
                        foreach (var path in attachmentPaths)
                        {
                            message.Attachments.Add(new Attachment(path));
                        }
                    }
                    SmtpClient client = new SmtpClient();
                    client.Send(message);
                }
            }
        }


        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("MM_dd_yyyy_HHmmss");
        }
    }
}
