
using Microsoft.EntityFrameworkCore;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask.Models.Entities.TaskModels;
using EmployeeTask.Models.Entities.JoinModels;
using Azure;
using EmployeeTask.Database.Configuring.Seed;

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
                e.HasMany(t => t.AssignedTasks).WithMany(a => a.Assignees);//.UsingEntity<EmployeeTaskEnt>();
                //    .UsingEntity(
                //"EmployeeTask",
                //l => l.HasOne(typeof(TaskEnt)).WithMany().HasForeignKey("TaskId").HasPrincipalKey(nameof(TaskEnt.Id)),
                //r => r.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.Id)),
                //j => j.HasKey("TaskId", "EmployeeId"));
                e.HasMany(t => t.Meetings).WithMany(a => a.Attendees);//UsingEntity<EmployeeTaskEnt>();
            //    .UsingEntity(
            //"EmployeeMeeting",
            //l => l.HasOne(typeof(Meeting)).WithMany().HasForeignKey("MeetingId").HasPrincipalKey(nameof(EmployeeTask.Models.Entities.MeetingModels.Meeting.Id)),
            //r => r.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.Id)),
            //j => j.HasKey("MeetingId", "EmployeeId"));

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
            //modelBuilder.SeedData();
        }
    }
}
