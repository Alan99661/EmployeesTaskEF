
using Microsoft.EntityFrameworkCore;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask.Models.Entities.TaskModels;
using EmployeeTask.Models.Entities.JoinModels;
using Azure;

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
                // e.Property(p => p.AssingnedTasks).IsRequired(false);
                e.HasMany(t => t.AssingnedTasks).WithMany(a => a.Assignees);//.UsingEntity<EmployeeTaskEnt>();

            });

            modelBuilder.Entity<TaskEnt>(t =>
            {
                t.HasKey(p => p.Id);
                t.Property(p => p.Title).IsRequired();
                t.Property(p=>p.IsCompleted).HasDefaultValue(false);
                t.HasMany(t => t.Assignees).WithMany(a => a.AssingnedTasks);//UsingEntity<EmployeeTaskEnt>();
                
                //t.Property(p => p.Assignees).IsRequired();
            });
            modelBuilder.Entity<Meeting>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Subject).IsRequired();
                // m.Property(p => p.Attendees).IsRequired();
                m.HasMany(p => p.Attendees).WithMany(a => a.AttendedMeetings).UsingEntity<EmployeeMeeting>();
            });

            //modelBuilder.Entity<Meeting>()
            //     .Property(m => m.Duration)
            //     .HasComputedColumnSql("[EndTime] - [StartTime]");

        }
    }
}
