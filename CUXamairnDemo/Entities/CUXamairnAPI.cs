using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System;
using CUXamairnDemo.Models.Day2;

namespace CUXamairnDemo.Entities
{
    public class CUXamairnAPI : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

          
           // optionsBuilder.UseSqlServer("Server = .;Database=CUXamairnAPI ; Trust-Connection=True ; Encrypt=False;TrustCertificate=True ");
            optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog = CUXamairnAPI; Integrated Security = True;  Encrypt = False;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

    }
}
