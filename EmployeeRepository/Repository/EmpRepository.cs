using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeRepository.Context;
using EmployeeRepository.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeRepository.Repository
{
    public class EmpRepository:IEmpRepository
    {
        private readonly UserContext context;
        public EmpRepository(UserContext context)
        {
            this.context = context;
        }

        public async Task<EmployeeDetails> AddEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            { 
                    this.context.Employee.Add(employeeDetails);
                    await this.context.SaveChangesAsync();
                    return employeeDetails;                                                            
            }
            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmployeeDetails> Delete(int EmployeeID)
        {
            try
            {
                var DeleteExist = await this.context.Employee.Where(x => x.EmployeeID == EmployeeID ).SingleOrDefaultAsync();       
                if (DeleteExist != null)
                {
                    this.context.Employee.Remove(DeleteExist);
                    await this.context.SaveChangesAsync();
                    return DeleteExist;           
                }
                return null;                     
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmployeeDetails> Edit(EmployeeDetails employee)
        {
            try
            {
                var EditExist =  await this.context.Employee.Where(x => x.EmployeeID == employee.EmployeeID).SingleOrDefaultAsync();     
                if (EditExist != null)
                {
                    EditExist.FullName = employee.FullName;
                    EditExist.Gender = employee.Gender;
                    EditExist.Salary = employee.Salary;
                    EditExist.StartDate = employee.StartDate;
                    EditExist.Department = employee.Department;

                    this.context.Employee.Update(EditExist);
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
        public IEnumerable<EmployeeDetails> Get(int EmployeeID)
        {
            try
            {
                IEnumerable<EmployeeDetails>GetExist = this.context.Employee.Where(x => x.EmployeeID == EmployeeID).ToList();
                if (GetExist.Count() != 0)
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
