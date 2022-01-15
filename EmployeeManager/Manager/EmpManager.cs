// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Raghavendra Narendra Wandre"/>
// ----------------------------------------------------------------------------------------------------------
namespace EmployeeManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeManager.Interface;
    using EmployeeModels;
    using EmployeeRepository.Interface;
   
    public class EmpManager : IEmpManager
    {
        readonly IEmpRepository Emprepository;
        public EmpManager(IEmpRepository Emprepository)
        {
            this.Emprepository = Emprepository;
        }
        public async Task<EmployeeDetails> AddEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            {
                return await this.Emprepository.AddEmployeeDetails(employeeDetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EmployeeDetails> Delete(int EmployeeID)
        {
            try
            {
                return await this.Emprepository.Delete(EmployeeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EmployeeDetails> Edit(int EmployeeID, string FullName, string Gender, int Salary, int StartDate, string Department)
        {
            try
            {
                return await this.Emprepository.Edit(EmployeeID,FullName,Gender,Salary,StartDate,Department);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<EmployeeDetails> Get()
        {
            try
            {
                return this.Emprepository.Get();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
