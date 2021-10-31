using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Helper
{
    public static class MailSender
    {
        public static string Mail(string Title, string Message)
        {
            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {

                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("kksw87kl@gmail.com", "123456789sS");
                    smtp.Send("kksw87kl@gmail.com", "essam9251@gmail.com", Title, Message);
                }

                return "Mail Sent";

            }
            catch (Exception ex)
            {
                return "Mail Faild";
            }

        }
    }
}
