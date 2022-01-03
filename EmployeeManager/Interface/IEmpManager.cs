using EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Interface
{
    public interface IEmpManager
    {
        string AddEmployeeDetails(EmployeeDetails employeeDetails);

        string Delete(string deleteData);

        string Edit(string edit, string gender, string department, int salary, int startDate);



    }
}
