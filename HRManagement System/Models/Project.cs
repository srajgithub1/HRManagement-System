using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement_System.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Title")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        [Display(Name="Client ")]
        public string Client { get; set; }
        [Required]
        [Display(Name = "Company ")]
        public string Company { get; set; }
        [Required]
        [Display(Name = "Project Manager ")]
        public string Manager { get; set; }
        [Required]
        [Display(Name = "Priority ")]
        public string Priority { get; set; }

        [Required]
        [Display(Name = "Assign To ")]
        public string Employee { get; set; }
        //[Required]
        //[Display(Name ="Allow project Date")]
        //[DataType(DataType.Date)]
        //public DateTime? DateOfStart { get; set; }
    }
}
