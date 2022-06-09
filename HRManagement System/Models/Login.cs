using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement_System.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Id")]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

