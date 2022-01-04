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
                var ifEmployeeDetails = this.context.Detail.Where(x => x.FullName == employeeDetails.FullName).SingleOrDefault();     //query
                if (ifEmployeeDetails == null)
                {
                    this.context.Detail.Add(employeeDetails);
                    this.context.SaveChanges();
                    return employeeDetails;                          //object
                }
                return null;                                         //object
            }
            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmployeeDetails Delete(string FullName)
        {
            try
            {
                var DeleteExist = this.context.Detail.Where(x => x.FullName == FullName).SingleOrDefault();        //query
                if (DeleteExist != null)
                {
                    this.context.Detail.Remove(DeleteExist);
                    this.context.SaveChangesAsync();
                    return DeleteExist;           //object
                }
                return null;                      // object
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmployeeDetails Edit(string FullName, string Gender, string Department, int Salary, int StartDate)
        {
            try
            {
                var EditExist =  this.context.Detail.Where(x => x.FullName == FullName).SingleOrDefault();     //query
                if (EditExist != null)
                {
                    EditExist.Salary = Salary;
                    EditExist.StartDate = StartDate;
                    EditExist.Department = Department;

                    this.context.Detail.Update(EditExist);
                    this.context.SaveChangesAsync();
                    return EditExist;                    //object
                }
                return null;                            // object
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
