// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Raghavendra Narendra Wandre"/>
// ----------------------------------------------------------------------------------------------------------
namespace EmployeeRepository.Interface
{
    using System.Threading.Tasks;
    using EmployeeModels;

    /// <summary>
    /// Interfaces of Repository file of User Registration
    /// </summary>
    public interface IUserRepository
    {
       Task<RegisterModel> Register(RegisterModel user);
        Task<string> Login(LoginModel loginDetails);
        Task<string> ResetPassword(ResetPasswordModel reset);
        Task<string> ForgetPassword(string Email); 
  
    }
}

