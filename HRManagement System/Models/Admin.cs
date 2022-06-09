using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement_System.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Full Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Id")]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [Compare("Password",ErrorMessage ="Password doesn't match  ")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string CPassword { get; set; }
    }
}
