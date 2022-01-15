using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeModels
{
    public class ForgetPasswordModel
    {

        [Required]
        public string Email { get; set; }
    }
}
