using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository.Interface
{
    public interface IEmpRepository
    {
        string AddEmployeeDetails(EmployeeDetails employeeDetails);
        string Delete(string deleteData);
        string Edit(string FullName, string Gender, string Department, int Salary, int StartDate);
    }
}
