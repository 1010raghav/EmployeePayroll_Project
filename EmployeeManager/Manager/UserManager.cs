using EmployeeManager.Interface;
using EmployeeModels;
using System;
using EmployeeRepository.Interface;
using System.Threading.Tasks;

namespace EmployeeManager.Manager
{
    public class UserManager : IUserManager
    {
        readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }



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
