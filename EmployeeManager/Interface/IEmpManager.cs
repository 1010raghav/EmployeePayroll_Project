using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Interface
{
    public interface IEmpManager
    {
        EmployeeDetails AddEmployeeDetails(EmployeeDetails employeeDetails);

        EmployeeDetails Delete(string deleteData);

        EmployeeDetails Edit(string edit, string gender, string department, int salary, int startDate);



    }
}
