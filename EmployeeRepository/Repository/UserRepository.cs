// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Raghavendra Narendra Wandre"/>
// ----------------------------------------------------------------------------------------------------------
namespace EmployeeRepository.Repository
{
    using System;
    using System.Linq;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using EmployeeModels;
    using EmployeeRepository.Context;
    using EmployeeRepository.Interface;
    using Experimental.System.Messaging;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using StackExchange.Redis;

    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;
        private readonly IConfiguration configuration;

        public UserRepository(UserContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// Register Method is for Registration New User details
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<RegisterModel> Register(RegisterModel user)
        {
            try
            {
                var ifExist = await this.context.Users.Where(x => x.Email == user.Email).SingleOrDefaultAsync();
                if (ifExist == null)
                {
                    this.context.Users.Add(user);
                    await this.context.SaveChangesAsync();
                    return user;
                }
                return null;
            }
            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        } 

        /// <summary>
        /// Login Method is for signing in the User Account
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        public async Task<string> Login(LoginModel loginDetails)
        {
            try
            {
                var ifEmailExist = await this.context.Users.Where(x => x.Email == loginDetails.Email).SingleOrDefaultAsync();
                if (ifEmailExist != null)
                {
                    var ifPasswordExist = await this.context.Users.Where(x => x.Password == loginDetails.Password).SingleOrDefaultAsync();
                    if (ifPasswordExist != null)
                    {
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(this.configuration["Connections:Connection"]);
                        IDatabase DataBase = connectionMultiplexer.GetDatabase();
                        DataBase.StringSet(key: "First Name", ifEmailExist.FirstName);
                        DataBase.StringSet(key: "Last Name", ifEmailExist.LastName);
                        DataBase.StringSet(key: "Email", ifEmailExist.Email);
                        DataBase.StringSet(key: "UserID", ifEmailExist.UserID).ToString();
                        return "Login Successful";  //return user != null ? "Login Successful" : "Login failed!! Email or password wrong"
                    }
                    return "Password Not Exist";
                }
                return "Email not exist";
            }
            catch (ArgumentNullException ex)    
            {
                throw new Exception(ex.Message);
            }
        } 

        /// <summary>
        /// Reset Method is for setting or changing the new password
        /// </summary>
        /// <param name="reset"></param>
        /// <returns></returns>
        public async Task<string> ResetPassword(ResetPasswordModel reset)
        {
            try
            {
                var Reset = await this.context.Users.Where(x => x.Email == reset.Email).FirstOrDefaultAsync();
                if (Reset != null)
                {
                    Reset.Password = reset.NewPassword;
                    this.context.Update(Reset);
                    await this.context.SaveChangesAsync();
                    return "Reset Successfully";
                }
                return "Reset Unsuccessful";
            }
            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forget method is for sending the link for forgetten password and to set new password.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public async Task<string> ForgetPassword(string Email)
        {
            try
            {
                var ifEmailExist = await this.context.Users.Where(x => x.Email == Email ).SingleOrDefaultAsync();
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
