
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
                e.HasMany(t => t.AssingnedTasks).WithMany(a => a.Assignees);//.UsingEntity<EmployeeTaskJoinModel>();

            });

            modelBuilder.Entity<TaskEnt>(t =>
            {
                t.HasKey(p => p.Id);
                t.Property(p => p.Title).IsRequired();
                t.HasMany(t => t.Assignees).WithMany(a => a.AssingnedTasks);//.UsingEntity<EmployeeTaskJoinModel>();
                //t.Property(p => p.Assignees).IsRequired();
            });
            modelBuilder.Entity<Meeting>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Subject).IsRequired();
                // m.Property(p => p.Attendees).IsRequired();
                m.HasMany(p => p.Attendees);
            });

            //modelBuilder.Entity<Meeting>()
            //     .Property(m => m.Duration)
            //     .HasComputedColumnSql("[EndTime] - [StartTime]");

            //var employees = new List<Employee>
            //{
            //    new Employee()
            //    {
            //        FullName = "Dio Brando",
            //        Email = "dio@hotmail.com",
            //        Birthday = DateTime.Today,
            //        PhoneNumber = "0881238979",
            //        Salary = 500.99m,
            //        CompletedTasks = new List<TaskEnt>() {}
            //    },
            //    new Employee()
            //    {
            //        FullName = "Jotaro Kujo",
            //        Email = "jotaro@gmail.com",
            //        Birthday = DateTime.Today,
            //        PhoneNumber = "0884567890",
            //        Salary = 700.50m,
            //        CompletedTasks = new List<TaskEnt>() {}
            //    },
            //    new Employee()
            //    {
            //        FullName = "Joseph Joestar",
            //        Email = "joseph@yahoo.com",
            //        Birthday = DateTime.Today,
            //        PhoneNumber = "0886781234",
            //        Salary = 600.75m,
            //        CompletedTasks = new List<TaskEnt>() {}
            //    },
            //    new Employee()
            //    {
            //        FullName = "Giorno Giovanna",
            //        Email = "giorno@hotmail.com",
            //        Birthday = DateTime.Today,
            //        PhoneNumber = "0884321567",
            //        Salary = 800.25m,
            //        CompletedTasks = new List<TaskEnt>() {}
            //    },
            //    new Employee()
            //    {
            //        FullName = "Josuke Higashikata",
            //        Email = "josuke@gmail.com",
            //        Birthday = DateTime.Today,
            //        PhoneNumber = "0887893456",
            //        Salary = 550.80m,
            //        CompletedTasks = new List<TaskEnt>() {}
            //    }
            //};
            //var tasks = new List<TaskEnt>()
            //{
            //    new TaskEnt()
            //    {
            //        Title = "FirstTask",
            //        Description = "Complete a Task",
            //        Assingnees = new List<Employee>() {employees[1]},
            //        DueDate = new DateTime(2024,12,03)
            //    },
            //    new TaskEnt()
            //    {
            //       Title = "SecondTask",
            //       Description = "Review project documentation",
            //       Assingnees = new List<Employee>() { employees[2], employees[3] },
            //       DueDate = new DateTime(2024, 10, 15)
            //    },
            //    new TaskEnt()
            //    {
            //        Title = "ThirdTask",
            //        Description = "Implement new feature",
            //        Assingnees = new List<Employee>() { employees[4] },
            //        DueDate = new DateTime(2024, 11, 30)
            //    }
            //};
            //var meetings = new List<Meeting>()
            //{
            //    new Meeting()
            //    {
            //        Attendees = new List<Employee> {employees[0],employees[2]},
            //        StartTime = new DateTime(2023,5,30,12,00,00),
            //        EndTime = new DateTime(2023,5,30,12,30,00),
            //        Subject = "Ted Talk"
            //    },
            //    new Meeting()
            //    {s
            //       Attendees = new List<Employee> { employees[1], employees[3], employees[4] },
            //       StartTime = new DateTime(2023, 6, 15, 9, 30, 00),
            //       EndTime = new DateTime(2023, 6, 15, 10, 30, 00),
            //       Subject = "Project Planning"

            //    },
            //    new Meeting()
            //    {
            //        Attendees = new List<Employee> { employees[0], employees[2], employees[3], employees[4] },
            //        StartTime = new DateTime(2023, 7, 5, 14, 00, 00),
            //        EndTime = new DateTime(2023, 7, 5, 15, 30, 00),
            //        Subject = "Team Update"
            //    }
            //};
            //modelBuilder.Entity<Employee>().HasData(employees);
            //modelBuilder.Entity<TaskEnt>().HasData(tasks);
            //modelBuilder.Entity<Meeting>().HasData(meetings);

        }
    }
}
