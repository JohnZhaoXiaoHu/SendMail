using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Mail
    {
        public static int Sendmail(string getmail, string title, string message)
        {
            try
            {
                string smtpServer = "smtp.qq.com"; //SMTP服务器
                string mailFrom = "code_test@qq.com"; //登陆用户名
                string userPassword = "whzfwobbzjxedjai";//登陆密码-新版之后的QQ邮箱都是使用授权码,需要到邮箱-设置-账户里面找到-生成授权码-复制进来

                // 邮件服务设置
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

                try
                {
                    smtpClient.Send(mailMessage); // 发送邮件
                    int i = 1;
                    return i;
                }
                catch (Exception)
                {
                    int i = 0;
                    return i;
                }
            }

            catch
            {
                int i = 0;
                return i;
            }
        }
    }
}
