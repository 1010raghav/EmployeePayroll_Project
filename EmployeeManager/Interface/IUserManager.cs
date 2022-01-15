namespace EmployeeManager.Interface
{
    using System.Threading.Tasks;
    using EmployeeModels;
    public interface IUserManager
    {
        Task<RegisterModel> Register(RegisterModel user);
        Task<string> Login(LoginModel loginDetails);
        Task<string> ResetPassword(ResetPasswordModel reset);
        Task<string> ForgetPassword(string Email); 
    }
}
