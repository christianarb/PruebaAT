using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATP.Exam.Models;

namespace ATP.Exam
{
    public class BusinessDBContext: DbContext
    {
        public BusinessDBContext(DbContextOptions<BusinessDBContext> options)
            : base(options) { }

        public DbSet<Project> Project { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ProjectEmployee> ProjectEmloyee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasKey(e => new { e.projectId});
            modelBuilder.Entity<Employee>().HasKey(e => new { e.employeeId });
            modelBuilder.Entity<ProjectEmployee>().HasKey(e => new { e.projectEmployeeId });

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pt => pt.Project)
                .WithMany(t => t.ProjectEmloyees)
                .HasForeignKey(b => b.projectId);

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pt => pt.Employee)
                .WithMany(t => t.ProjectEmloyees)
                .HasForeignKey(b => b.employeeId);

            modelBuilder.Entity<Project>()
                .Property(x => x.cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Employee>()
                .Property(x => x.salary)
                .HasPrecision(10, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}