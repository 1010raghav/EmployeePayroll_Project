using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeModels;


namespace EmployeeRepository.Interface
{
    public interface IUserRepository
    {
        string Register(RegisterModel user);
        string Login(LoginModel loginDetails);
        string ResetPassword(ResetPasswordModel reset);
        string ForgetPassword(string Email);
    }
}
