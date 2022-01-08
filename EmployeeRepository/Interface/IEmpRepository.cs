using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository.Interface
{
    public interface IEmpRepository
    {
        EmployeeDetails AddEmployeeDetails(EmployeeDetails employeeDetails);
        EmployeeDetails Delete(int deleteData);
        EmployeeDetails Edit(EmployeeDetails employee);
        IEnumerable<EmployeeDetails> Get(int getData);
    }
}

