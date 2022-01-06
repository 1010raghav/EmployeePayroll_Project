using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeRepository.Context;
using EmployeeRepository.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRepository.Repository
{
    public class EmpRepository:IEmpRepository
    {
        private readonly UserContext context;
        public EmpRepository(UserContext context)
        {
            this.context = context;
        }

        public EmployeeDetails AddEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            {
                var ifEmployeeDetails = this.context.Employee.Where(x => x.EmployeeID == employeeDetails.EmployeeID).SingleOrDefault();   
                if (ifEmployeeDetails == null)
                {
                    this.context.Employee.Add(employeeDetails);
                    this.context.SaveChanges();
                    return employeeDetails;                          
                }
                return null;                                        
            }
            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmployeeDetails Delete(int EmployeeID)
        {
            try
            {
                var DeleteExist = this.context.Employee.Where(x => x.EmployeeID == EmployeeID ).SingleOrDefault();       
                if (DeleteExist != null)
                {
                    this.context.Employee.Remove(DeleteExist);
                    this.context.SaveChanges();
                    return DeleteExist;           
                }
                return null;                     
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmployeeDetails Edit(EmployeeDetails employee)
        {
            try
            {
                var EditExist =  this.context.Employee.Where(x => x.EmployeeID == employee.EmployeeID).SingleOrDefault();     
                if (EditExist != null)
                {
                    EditExist.Salary = employee.Salary;
                    EditExist.StartDate = employee.StartDate;
                    EditExist.Department = employee.Department;

                    this.context.Employee.Update(EditExist);
                    this.context.SaveChanges();
                    return EditExist;                    
                }
                return null;                           
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public IEnumerable<EmployeeDetails >Get(int EmployeeID)
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
