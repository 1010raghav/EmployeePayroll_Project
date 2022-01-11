//-----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
// Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="A Raghavendra Wandre"/>
//-----------------------------------------------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmployeeModels;
using EmployeeManager.Interface;

namespace EmployeeNote.Controller
{
    /// <summary>
    /// UserController class for Users API implementation
    /// </summary>
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        ///  Register for new User
        /// </summary>
        /// <param name="user">User Data</param>
        /// <returns>This methods returns IActionResult for User Registration</returns>
        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel user)
        {
            try
            {
                var message = await this.manager.Register(user);
                if (message != null )
                {
                    return this.Ok(new { Status = true, Message = "Registration is Successfull", Data = message});
                }
                else
                {
                    return this.BadRequest(new  { Status = false, Message = "Registration is Not Successfull"});
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new  { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Login with Registed Details
        /// </summary>
        /// <param name="loginDetails">User Data</param>
        /// <returns>This methods returns IActionResult for User Login</returns>
        [HttpGet]
        [Route("api/Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                string message = await this.manager.Login(loginDetails);
                if (message != "Login Unsuccessful")
                {
                    return this.Ok(new ResponseModel<string> { Status = true, Message = message});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message= ex.Message });
            }
        }
        /// <summary>
        /// Reset the Pervious Password 
        /// </summary>
        /// <param name="reset">User Data</param>
        /// <returns>This methods returns IActionResult for User Reset</returns>
        [HttpPut]
        [Route("api/ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel reset)
        {
            try
            {
                var message = await this .manager.ResetPassword(reset);
                if (message != "Reset Unsuccessfully")
                {
                    return this.Ok(new { Status = true, Message = "Reset Successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Reset Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Forget Retrive the Password and gives new Password to set
        /// </summary>
        /// <param name="Email">It is the emailId of the user where we are sending the test email</param>
        /// <returns>This methods returns IActionResult for Forget Password</returns>
        [HttpPut]
        [Route("api/ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string Email)
        {
            try
            {
                var message = await this.manager.ForgetPassword(Email);


                if (message.Equals(true))
                {

                    return this.Ok(new ResponseModel<string> { Status = true, Message = "Reset Link Sent to Your Email Successfully" });
                }
                else
                {

                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Error in sending the Email" });
                }
            }
            catch (Exception ex)
            {

                return this.NotFound(new ResponseModel<string> { Status = false, Message= ex.Message });
            }
        }
    }
}
