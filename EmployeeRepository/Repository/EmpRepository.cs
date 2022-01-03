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

        public string AddEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            {
                var ifEmployeeDetails = this.context.Detail.Where(x => x.FullName == employeeDetails.FullName).SingleOrDefault();
                if (ifEmployeeDetails == null)
                {
                    this.context.Detail.Add(employeeDetails);
                    this.context.SaveChanges();
                    return "Employee Details is Added Successfully "; 
                }
                return "Error : Employee Details Not Added";
            }
            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Delete(string FullName)
        {
            try
            {
                var DeleteExist = this.context.Detail.Where(x => x.FullName == FullName).SingleOrDefault();
                if (DeleteExist != null)
                {
                    this.context.Detail.Remove(DeleteExist);
                    this.context.SaveChangesAsync();
                    return "Data Deleted Successfully";
                }
                return "Data Not Exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Edit(string FullName, string Gender, string Department, int Salary, int StartDate)
        {
            try
            {
                var EditExist =  this.context.Detail.Where(x => x.FullName == FullName).SingleOrDefault();
                if (EditExist != null)
                {
                    EditExist.Salary = Salary;
                    EditExist.StartDate = StartDate;
                    EditExist.Department = Department;

                    this.context.Detail.Update(EditExist);
                    this.context.SaveChangesAsync();
                    return "Data Edited Successfully";
                }
                return "Data not Exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
