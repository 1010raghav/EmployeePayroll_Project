using EmployeeModels;
using System.Threading.Tasks;

namespace EmployeeManager.Interface
{
    public interface IUserManager
    {
        Task<RegisterModel> Register(RegisterModel user);
        Task<string> Login(LoginModel loginDetails);
        Task<string> ResetPassword(ResetPasswordModel reset);
        Task<string> ForgetPassword(string Email);
    }
}
