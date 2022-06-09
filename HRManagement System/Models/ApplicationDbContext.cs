using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement_System.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Admin> admins { get; set; } 
        public DbSet<Project> projects { get; set; }
        public DbSet<Training> trainings { get; set; }
    }
}
