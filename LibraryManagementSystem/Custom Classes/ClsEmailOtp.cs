using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.Custom_Classes
{
    internal class ClsEmailOtp
    {
        public static int EmailSender(string To, string From, string Subject, string Body)
        {
            try
            {
                MailMessage Message = new MailMessage();
                Message.To.Add(To);
                Message.From = new MailAddress(From);
                Message.Subject = Subject;
                Message.Body = Body;
                Message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new NetworkCredential(From, "qaqumdmgnysvjpna");
                smtp.EnableSsl = true;
                smtp.Send(Message);
                MessageBox.Show("OTP has been sent");
                return 1;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                 return 0;
            }

        }
        public static string GenerateOtp()
        {
            var value = "0123456789";
            int index;
            string Otpcode = "";
            Random obj = new Random();
            for (int i = 0; i < 4; i++)
            {
                index = obj.Next(0, value.Length - 1);
                Otpcode += "" + value[index];
            }
            return Otpcode;
        }
    }
}
