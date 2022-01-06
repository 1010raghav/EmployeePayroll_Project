using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Interface
{
    public interface IEmpManager
    {
        EmployeeDetails AddEmployeeDetails(EmployeeDetails employeeDetails);

        EmployeeDetails Delete(int deleteData);

        EmployeeDetails Edit(EmployeeDetails employee);

        IEnumerable<EmployeeDetails> GetEmployee(int getData);

    }
}
