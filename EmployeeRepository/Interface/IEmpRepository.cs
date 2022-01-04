using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository.Interface
{
    public interface IEmpRepository
    {
        EmployeeDetails AddEmployeeDetails(EmployeeDetails employeeDetails);
        EmployeeDetails Delete(string deleteData);
        EmployeeDetails Edit(string FullName, string Gender, string Department, int Salary, int StartDate);
    }
}
