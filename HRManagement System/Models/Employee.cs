using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement_System.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        [Display(Name ="Contact No.")]
        [Phone]
        public string Contact { get; set; }
        [Required]
        [Display(Name="Blood Group")]
        public string Blood { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string Experience { get; set; }
        
    }
}
