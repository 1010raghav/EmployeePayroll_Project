namespace EmployeeRepository.Interface
{
    using System.Threading.Tasks;
    using EmployeeModels;

    public interface IUserRepository
    {
       Task<RegisterModel> Register(RegisterModel user);
        Task<string> Login(LoginModel loginDetails);
        Task<string> ResetPassword(ResetPasswordModel reset);
        Task<string> ForgetPassword(string Email); 
  
    }
}

