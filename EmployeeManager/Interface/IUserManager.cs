using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Interface
{
    public interface IUserManager
    {
        RegisterModel Register(RegisterModel user);
        string Login(LoginModel loginDetails);
        string ResetPassword(ResetPasswordModel reset);
        string ForgetPassword(string Email);


    }
}
