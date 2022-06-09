using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement_System.Models
{
    public class ChangePassword
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]

        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NPassword", ErrorMessage =
        "The new password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public string CPassword { get; set; }
    }
}
