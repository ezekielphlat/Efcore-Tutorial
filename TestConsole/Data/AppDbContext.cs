using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestConsole.Models;

namespace TestConsole.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=casa-staging.csnws8ycexu0.us-east-1.rds.amazonaws.com;Port=3306;Database=testconsole;Uid=casastagingadmin;Pwd=SecujdgfhacareP0#;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure primary keys
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
            //configure rquired fields
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpFirstName)
                .IsRequired();
            // Configure one-to-one relationship between Employee and EmployeeDetails
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.EmployeeDetails)
                .WithOne(ed => ed.Employee)
                .HasForeignKey<EmployeeDetails>(ed => ed.EmployeeId);
            // Configure one-to-many relationship between Manager and Employee
            modelBuilder.Entity<Manager>()
                .HasMany(m => m.Employees)
                .WithOne(e => e.Manager)
                .HasForeignKey(e => e.ManagerId);
            // configure many-to-many relationship between Employee and Project via EmployeeProject
            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });
            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);
            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);
        }
    }
}
