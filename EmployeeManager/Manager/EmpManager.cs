using EmployeeManager.Interface;
using EmployeeModels;
using EmployeeRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Manager
{
    public class EmpManager : IEmpManager
    {
        readonly IEmpRepository Emprepository;
        public EmpManager(IEmpRepository Emprepository)
        {
            this.Emprepository = Emprepository;
        }


        public EmployeeDetails AddEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            {
                return this.Emprepository.AddEmployeeDetails(employeeDetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public EmployeeDetails Delete(string deleteData)
        {
            try
            {
                return this.Emprepository.Delete(deleteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmployeeDetails Edit(string edit, string gender, string department, int salary, int startDate)
        {
            try
            {
                return this.Emprepository.Edit(edit,gender,department,salary,startDate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
