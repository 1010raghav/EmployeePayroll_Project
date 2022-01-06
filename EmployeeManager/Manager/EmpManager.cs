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


        public EmployeeDetails Delete(int deleteData)
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

        public EmployeeDetails Edit(EmployeeDetails employee)
        {
            try
            {
                return this.Emprepository.Edit(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<EmployeeDetails> GetEmployee(int getData)
        {
            try
            {
                return this.Emprepository.Get(getData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
