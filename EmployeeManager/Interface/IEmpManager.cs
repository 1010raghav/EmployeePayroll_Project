using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Interface
{
    public interface IEmpManager
    {
        Task<EmployeeDetails> AddEmployeeDetails(EmployeeDetails employeeDetails);
        Task<EmployeeDetails> Delete(int deleteData);
        Task<EmployeeDetails> Edit(EmployeeDetails employee);
        IEnumerable<EmployeeDetails> GetEmployee(EmployeeDetails getData);
    }
}
