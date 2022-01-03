using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeModels;
using EmployeeManager.Interface;

namespace EmployeeNote.Controller
{
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody] RegisterModel user)
        {
            try
            {
                string message = this.manager.Register(user);
                if (message.Equals("Register Successfully"))
                {
                    return this.Ok(new { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = message });
                }

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }





        [HttpGet]
        [Route("api/Login")]
        public IActionResult Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                string message = this.manager.Login(loginDetails);
                if (message.Equals("Login Successful"))
                {
                    return this.Ok(new { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel reset)
        {
            try
            {
                string message = this.manager.ResetPassword(reset);
                if (message.Equals(true))
                {
                    return this.Ok(new { Status = true, Message = "Reset Successful" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Reset Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }



        [HttpPost]
        [Route("forgotPassword")]
        public IActionResult ForgetPassword(string Email)
        {
            try
            {
                string message = this.manager.ForgetPassword(Email);


                if (message.Equals("Reset Link Sent to Your Email Successfully"))
                {

                    return this.Ok(new { Status = true, Message = message });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {

                return this.NotFound(new { Status = false, ex.Message });
            }
        }



    }
}
