using EmployeeManager.Interface;
using EmployeeModels;
using System;
using EmployeeRepository.Interface;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Manager
{
    public class UserManager : IUserManager
    {
        readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }


        public string Register(RegisterModel user)
        {
            try
            {
                return this.repository.Register(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Login(LoginModel loginDetails)
        {
            try
            {
                return this.repository.Login(loginDetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ResetPassword(ResetPasswordModel reset)
        {
            try
            {
                return this.repository.ResetPassword(reset);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ForgetPassword(string Email)
        {
            try
            {
                return this.repository.ForgetPassword(Email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
