using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Register([FromBody] RegisterModel user)
        {
            try
            {
                var message = await this.manager.Register(user);
                if (message != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Registration is Successfull", Data = message.ToString() });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Registration is Not Successfull" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/Login")]
        public  async Task<IActionResult> Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                var message = await this .manager.Login(loginDetails);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string> { Status = true, Message = "Login Successful" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string> { Status = false, Message = "Login Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message= ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel reset)
        {
            try
            {
                var message = await this.manager.ResetPassword(reset);
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
