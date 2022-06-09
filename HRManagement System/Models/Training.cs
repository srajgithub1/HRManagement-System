using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement_System.Models
{
    public class Training
    {
        [Key]
        [Display(Name ="SR.No")]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Training Project")]
        public string Project { get; set; }
        [Required]
        [Display(Name = "Assign To")]
        public string employee { get; set; }  
    }
}
