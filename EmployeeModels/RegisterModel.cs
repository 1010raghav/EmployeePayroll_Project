using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeModels
{
    public class RegisterModel
    {
        [Key]

        public string FirstName{ get; set; }
        public string LastName { get; set; }


        //public string FullName { get; set; }
        //public string Gender { get; set; }
        //public string Department { get; set; }
        //public int Salary { get; set; }
        //public int StartDate { get; set; }
        //public string Notes { get; set; }


        [Required]
        // [RegularExpression("",ErrorMessage = "E-mail is not valid. Please Enter Valid email")]

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
