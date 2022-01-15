// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Raghavendra Narendra Wandre"/>
// ----------------------------------------------------------------------------------------------------------
namespace EmployeeNote.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using EmployeeModels;
    using EmployeeManager.Interface;
    using Microsoft.Extensions.Logging;

    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        private readonly ILogger<UserController> logger;

        public UserController(IUserManager manager,ILogger<UserController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel user)
        {
            try
            {
                this.logger.LogInformation(user.FirstName + "is trying to Register");
                var message = await this.manager.Register(user);
                if (message != null)
                {
                    this.logger.LogInformation(user.FirstName + ": Has Successfully Register");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Registration is Successfull", Data = message.ToString() });
                }
                else
                {
                    this.logger.LogInformation(user.FirstName + ": Registration Was Unsuccessful");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Registration is Not Successfull" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation(user.FirstName + "had exception while registration :-");
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Login")]
        public  async Task<IActionResult> Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                this.logger.LogInformation(loginDetails.Email + "is trying to Login");
                var message = await this .manager.Login(loginDetails);
                if (message == "Login Successful")
                {
                    this.logger.LogInformation(loginDetails.Email + ": has Successfully Logined ");
                    return this.Ok(new ResponseModel<string> { Status = true, Message = "Login Successful" });
                }
                else
                {
                    this.logger.LogInformation(loginDetails.Email + ": has Failed to Login");
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Login Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation(loginDetails.Email + "had exception while Login");
                return this.NotFound(new ResponseModel<string> { Status = false, Message= ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reset"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel reset)
        {
            try
            {
                this.logger.LogInformation(reset.Email + "is trying to reset");
                var message = await this.manager.ResetPassword(reset);
                if (message == "Reset Successfully")
                {
                    this.logger.LogInformation(reset.Email + ": has Successfully Reset the Password");
                    return this.Ok(new  { Status = true, Message = "Reset Successful", Data = message.ToString() });
                }
                else
                {
                    this.logger.LogInformation(reset.Email + ": Failed to Reset the Password");
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Reset Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation(reset.Email + ": had exception while Reset the Password");
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string Email)
        {
            try
            {
                this.logger.LogInformation(Email+ "is trying to forget");
                var message = await this.manager.ForgetPassword(Email);
                if (message != null )
                {
                    this.logger.LogInformation(Email + " has Successfully send the link to Email");
                    return this.Ok(new { Status = true, Message = message, data= "Successfully send the link to Email"});
                }
                else
                {
                    this.logger.LogInformation(Email + " Failed to send the link to Email");
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Error in sending the Email" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation(Email + "Had Exception while sending the Email");
                return this.NotFound(new ResponseModel<string> { Status = false, Message= ex.Message }); 
            }
        }
    }
}
