// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmployeeManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Raghavendra Narendra Wandre"/>
// ----------------------------------------------------------------------------------------------------------
namespace EmployeeManager.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeModels;

    public interface IEmpManager
    {
        /// <summary>
        /// Interfaces of Manager file of Employee Payroll Details 
        /// </summary>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        Task<EmployeeDetails> AddEmployeeDetails(EmployeeDetails employeeDetails);
        Task<EmployeeDetails> Delete(int EmployeeID);
        Task<EmployeeDetails> Edit(int EmployeeID, string FullName, string Gender, int Salary, int StartDate, string Department);
        IEnumerable<EmployeeDetails> Get();
    }
}
