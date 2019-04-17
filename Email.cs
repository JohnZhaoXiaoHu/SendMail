using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

namespace Until
{
   public class Email
    {
        public static bool Sendmail(string getmail, string title, string message,string mailFrom, string userPassword)
        {
            // 邮件服务设置
            string smtpServer = "smtp.qq.com"; //SMTP服务器
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.EnableSsl = true;//由于使用了授权码必须设置该属性为true
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码

            // 发送邮件设置       
            MailMessage mailMessage = new MailMessage(mailFrom, getmail); // 发送人和收件人
            mailMessage.Subject = title;//主题
            mailMessage.Body = message;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.Low;//优先级

            bool b = false;
            try
            {
                smtpClient.Send(mailMessage); // 发送邮件
                b = true;
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }
    }
}
