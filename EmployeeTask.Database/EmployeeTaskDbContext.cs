
using Microsoft.EntityFrameworkCore;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask.Models.Entities.TaskModels;
using Azure;
using EmployeeTask.Database.Configuring.Seed;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.Database
{
    public class EmployeeTaskDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskEnt> Tasks { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public EmployeeTaskDbContext(DbContextOptions<EmployeeTaskDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.FullName).IsRequired();
                e.Property(p => p.Birthday).HasColumnType("date");
                e.HasMany(t => t.AssignedTasks).WithMany(a => a.Assignees);
                e.HasMany(t => t.Meetings).WithMany(a => a.Attendees);
            });

            modelBuilder.Entity<TaskEnt>(t =>
            {
                t.HasKey(p => p.Id);
                t.Property(p => p.Title).IsRequired();
                t.Property(p=>p.IsCompleted).HasDefaultValue(false);
            });
            modelBuilder.Entity<Meeting>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Subject).IsRequired();
            });
        }
    }
}
