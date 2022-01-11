using EmployeeManager.Interface;
using EmployeeModels;
using EmployeeRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Manager
{
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
        public async Task<EmployeeDetails> Delete(int deleteData)
        {
            try
            {
                return await this.Emprepository.Delete(deleteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EmployeeDetails> Edit(EmployeeDetails employee)
        {
            try
            {
                return await this.Emprepository.Edit(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<EmployeeDetails> GetEmployee(EmployeeDetails getData)
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
