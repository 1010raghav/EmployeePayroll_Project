using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeModels
{
    public class EmployeeDetails
    {
        [Key]
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public int StartDate { get; set; }

        
        


    }
}
