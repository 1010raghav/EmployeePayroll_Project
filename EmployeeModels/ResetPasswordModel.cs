using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeModels
{
    public class ResetPasswordModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
