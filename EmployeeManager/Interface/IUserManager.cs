// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Raghavendra Narendra Wandre"/>
// ----------------------------------------------------------------------------------------------------------
namespace EmployeeManager.Interface
{
    using System.Threading.Tasks;
    using EmployeeModels;

    /// <summary>
    /// Interfaces of Manager file of User Registration
    /// </summary>
    public interface IUserManager
    { 
        Task<RegisterModel> Register(RegisterModel user);
        Task<string> Login(LoginModel loginDetails);
        Task<string> ResetPassword(ResetPasswordModel reset);
        Task<string> ForgetPassword(string Email); 
    }
}
