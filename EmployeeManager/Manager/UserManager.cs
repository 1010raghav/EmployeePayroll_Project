// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Raghavendra Narendra Wandre"/>
// ----------------------------------------------------------------------------------------------------------
namespace EmployeeManager.Manager
{
    using System;
    using System.Threading.Tasks;
    using EmployeeManager.Interface;
    using EmployeeModels;
    using EmployeeRepository.Interface;
  
    /// <summary>
    /// Constructor Injection
    /// </summary>
    public class UserManager : IUserManager
    {
        readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<RegisterModel> Register(RegisterModel user)
        {
            try
            {
                return await this.repository.Register(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        public async Task<string> Login(LoginModel loginDetails)
        {
            try
            {
                return await this.repository.Login(loginDetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Reset
        /// </summary>
        /// <param name="reset"></param>
        /// <returns></returns>
        public async Task<string> ResetPassword(ResetPasswordModel reset)
        {
            try
            {
                return await this.repository.ResetPassword(reset);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forget
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public async Task<string> ForgetPassword(string Email)
        {
            try
            {
                return await this.repository.ForgetPassword(Email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }
    }
}
