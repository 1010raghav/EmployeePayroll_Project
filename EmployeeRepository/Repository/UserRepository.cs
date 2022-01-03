using EmployeeModels;
using EmployeeRepository.Context;
using EmployeeRepository.Interface;
using Experimental.System.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;
        private readonly IConfiguration configuration;

        public UserRepository(UserContext context, IConfiguration configuration)
        {

            this.context = context;
            this.configuration = configuration;
        }

        public string Register(RegisterModel user)
        {
            try
            {
                var ifExist = this.context.User.Where(x => x.Email == user.Email).SingleOrDefault();
                if (ifExist == null)
                {
                    this.context.User.Add(user);
                    this.context.SaveChanges();
                    return "Register Successfully";

                }
                return "Email already exist";
            }
            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        


        public string Login(LoginModel loginDetails)
        {
            try
            {
                var ifLoginExist = this.context.User.Where(x => x.Email == loginDetails.Email && x.Password == loginDetails.Password).SingleOrDefault();
                if (ifLoginExist != null)
                {
                    return "Login Successful";
                }
                return "Email not exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EncryptPassword(string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public string ResetPassword(ResetPasswordModel reset)
        {
            try
            {
                var Reset = this.context.User.Where(x => x.Email == reset.Email).FirstOrDefault();
                if (Reset != null)

                {
                    Reset.Password = EncryptPassword(reset.NewPassword);

                    this.context.Update(Reset);
                    this.context.SaveChanges();
                    return "Reset Successfully";

                }
                return "Reset Unsuccessful";
            }

            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string ForgetPassword(string Email)
        {
            try
            {
                var ifEmailExist = this.context.User.Where(x => x.Email == Email).SingleOrDefaultAsync();
                if (ifEmailExist != null)
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress(this.configuration["Credentials:Email"]);
                    mail.To.Add(Email);
                    SendMSMQ();
                    mail.Body = RecieveMSMQ();

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(this.configuration["Credentials:Email"], this.configuration["Credentials:Password"]);
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    return "Reset Link Sent to Your Email Successfully";
                }
                return "Email not Exist";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        private void SendMSMQ()
        {
            MessageQueue msgqueue;
            if (MessageQueue.Exists(@".\Private$\EmployeePayroll"))
            {
                msgqueue = new MessageQueue(@".\Private$\EmployeePayroll");
            }
            else
            {
                msgqueue = MessageQueue.Create(@".\Private$\EmployeePayroll");
            }
            msgqueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            string body = "This is Password reset link.";
            msgqueue.Label = "Mail Body";
            msgqueue.Send(body);
        }

        private static string RecieveMSMQ()
        {
            MessageQueue msgqueue = new MessageQueue(@".\Private$\EmployeePayroll");
            var recievemsg = msgqueue.Receive();
            recievemsg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            return recievemsg.Body.ToString();
        }

       
    }
}
