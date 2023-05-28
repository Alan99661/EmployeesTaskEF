using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask.Models.Entities.TaskModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Database.Configuring.Seed
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            Debugger.Launch();
            var employees = new List<Employee>
            {
                new Employee()
                {
                    FullName = "Dio Brando",
                    Email = "dio@hotmail.com",
                    Birthday = DateTime.Today,
                    PhoneNumber = "0881238979",
                    Salary = 500.99m,
                },
                new Employee()
                {
                    FullName = "Jotaro Kujo",
                    Email = "jotaro@gmail.com",
                    Birthday = DateTime.Today,
                    PhoneNumber = "0884567890",
                    Salary = 700.50m,
                    AssignedTasks = new List<TaskEnt>() {}
                },
                new Employee()
                {
                    FullName = "Joseph Joestar",
                    Email = "joseph@yahoo.com",
                    Birthday = DateTime.Today,
                    PhoneNumber = "0886781234",
                    Salary = 600.75m
                },
                new Employee()
                {
                    FullName = "Giorno Giovanna",
                    Email = "giorno@hotmail.com",
                    Birthday = DateTime.Today,
                    PhoneNumber = "0884321567",
                    Salary = 800.25m
                },
                new Employee()
                {
                    FullName = "Josuke Higashikata",
                    Email = "josuke@gmail.com",
                    Birthday = DateTime.Today,
                    PhoneNumber = "0887893456",
                    Salary = 550.80m
                }
            };
            var tasks = new List<TaskEnt>()
            {
                new TaskEnt()
                {
                    Title = "FirstTask",
                    Description = "Complete a Task",
                    Assignees = new List<Employee>() {employees[1]},
                    DueDate = new DateTime(2024,12,03)
                },
                new TaskEnt()
                {
                   Title = "SecondTask",
                   Description = "Review project documentation",
                   Assignees = new List<Employee>() { employees[2], employees[3] },
                   DueDate = new DateTime(2024, 10, 15)
                },
                new TaskEnt()
                {
                    Title = "ThirdTask",
                    Description = "Implement new feature",
                    Assignees = new List<Employee>() { employees[4] },
                    DueDate = new DateTime(2024, 11, 30)
                }
            };
            var meetings = new List<Meeting>()
            {
                new Meeting()
                {
                    Attendees = new List<Employee> {employees[0],employees[2]},
                    StartTime = new DateTime(2023,5,30,12,00,00),
                    EndTime = new DateTime(2023,5,30,12,30,00),
                    Subject = "Ted Talk"
                },
                new Meeting()
                {
                   Attendees = new List<Employee> { employees[1], employees[3], employees[2] },
                   StartTime = new DateTime(2023, 6, 15, 9, 30, 00),
                   EndTime = new DateTime(2023, 6, 15, 10, 30, 00),
                   Subject = "Project Planning"

                },
                new Meeting()
                {
                    Attendees = new List<Employee> { employees[0], employees[2], employees[3], employees[1] },
                    StartTime = new DateTime(2023, 7, 5, 14, 00, 00),
                    EndTime = new DateTime(2023, 7, 5, 15, 30, 00),
                    Subject = "Team Update"
                }
            };
            modelBuilder.Entity<Employee>().HasData(employees);
            modelBuilder.Entity<TaskEnt>().HasData(tasks);
            modelBuilder.Entity<Meeting>().HasData(meetings);
           
        }
    }
}
