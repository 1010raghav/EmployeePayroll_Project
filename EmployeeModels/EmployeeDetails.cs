using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeModels
{
    public class EmployeeDetails
    {
        [Key]
        public int EmployeeID { get; set; }

        [ForeignKey("RegisterModel")]
        public int UserID { get; set; }
        
        public virtual RegisterModel user { get; set; }

        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public int StartDate { get; set; }

        
        


    }
}
