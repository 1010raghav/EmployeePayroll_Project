using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeModels;


namespace EmployeeRepository.Interface
{
    public interface IUserRepository
    {
       Task<RegisterModel> Register(RegisterModel user);
        Task<string> Login(LoginModel loginDetails);
        Task<string> ResetPassword(ResetPasswordModel reset);
        Task<string> ForgetPassword(string Email);
    }
}

