using System;
using System.Collections.Generic;
using System.Text;
using HR.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Database
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> hrDbContextOptions) : base(hrDbContextOptions)
        {
            
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(emp => emp.EmployeeAddress)
                .WithOne(empAd => empAd.Employee)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeAddress>()
                .HasOne(empAd => empAd.Employee)
                .WithOne(emp => emp.EmployeeAddress)
                .HasForeignKey<EmployeeAddress>(e => e.EmployeeId);
        }
    }
}
