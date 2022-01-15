// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmployeeRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Raghavendra Narendra Wandre"/>
// ----------------------------------------------------------------------------------------------------------
namespace EmployeeRepository.Repository
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using EmployeeModels;
    using EmployeeRepository.Context;
    using EmployeeRepository.Interface;
    using Microsoft.EntityFrameworkCore;

    public class EmpRepository:IEmpRepository
    {
        private readonly UserContext context;
        public EmpRepository(UserContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Add Employee Details Method is for adding the new Employee Details 
        /// </summary>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        public async Task<EmployeeDetails> AddEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            { 
                this.context.Employees.Add(employeeDetails);
                await this.context.SaveChangesAsync();
                return employeeDetails;                                                            
            }
            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Employee Details Method is for deleting data of Employee.
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public async Task<EmployeeDetails> Delete(int EmployeeID)
        {
            try
            {
                var DeleteExist = await this.context.Employees.Where(x => x.EmployeeID == EmployeeID ).SingleOrDefaultAsync();       
                if (DeleteExist != null)
                {
                    this.context.Employees.Remove(DeleteExist);
                    await this.context.SaveChangesAsync();
                    return DeleteExist ;           
                }
                return null;                     
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edit Employee Details Method is for Modifing the Existing Employee Details.
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="FullName"></param>
        /// <param name="Gender"></param>
        /// <param name="Salary"></param>
        /// <param name="StartDate"></param>
        /// <param name="Department"></param>
        /// <returns></returns>
        public async Task<EmployeeDetails> Edit(int EmployeeID, string FullName,string Gender, int Salary, int StartDate, string Department)
        {
            try
            {
                var EditExist =  await this.context.Employees.Where(x => x.EmployeeID == EmployeeID).SingleOrDefaultAsync();     
                if (EditExist != null)
                {
                    EditExist.FullName = FullName;
                    EditExist.Gender = Gender;
                    EditExist.Salary = Salary;
                    EditExist.StartDate = StartDate;
                    EditExist.Department = Department;
                    this.context.Employees.Update(EditExist);
                    await this.context.SaveChangesAsync();
                    return EditExist;                    
                }
                return null;                           
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get method is for Displaying the all Registered Employee. 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeDetails> Get()
        {
            try
            { 
                IEnumerable<EmployeeDetails> GetExist = this.context.Employees.ToList();
                if (GetExist != null)
                {
                    return GetExist;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
