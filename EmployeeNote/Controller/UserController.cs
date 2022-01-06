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

       /// <summary>
       ///  Register
       /// </summary>
       /// <param name="user"></param>
       /// <returns></returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody] RegisterModel user)
        {
            try
            {
                var message = this.manager.Register(user);
                if (message != null )
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Registration is Successfull", Data = message.ToString()});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Registration is Not Successfull"});
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Login")]
        public IActionResult Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                string message = this.manager.Login(loginDetails);
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

        [HttpPut]
        [Route("api/ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel reset)
        {
            try
            {
                var message = this.manager.ResetPassword(reset);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string> { Status = true, Message = "Reset Successful" });
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

        [HttpPost]
        [Route("forgotPassword")]
        public IActionResult ForgetPassword(string Email)
        {
            try
            {
                var message = this.manager.ForgetPassword(Email);


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
