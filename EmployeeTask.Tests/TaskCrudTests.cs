using AutoMapper;
using EmployeeTask.Database;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask.Models.Entities.TaskModels;
using EmployeeTask_Services.Constracts;
using EmployeeTask_Services.Cruds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeTask.Tests
{
    [TestClass]
    public class TaskCrudTests
    {
        [Fact]
        public void TestGetAllSuccsess()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<TaskEnt, TaskViewModel>().ReverseMap();
                x.CreateMap<TaskEnt, TaskAddModel>().ReverseMap();
                //x.CreateMap<Task,TaskUpdateModel>().ReverseMap();
            });
            Mapper mapper = new Mapper(configuration);
            TaskCrudOperations service = new TaskCrudOperations(dbContext, mapper);

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
                    Salary = 700.50m
                }
            };

            var addmodel = new TaskAddModel()
            {
                Title = "FirstTask",
                Description = "Complete a Task",
                AssigneeIds = new List<string> { employees[0].Id, employees[1].Id },
                DueDate = new DateTime(2024, 12, 03),
                IsCompleted = false
            };
            //Act
            service.CreateTask(addmodel);
            var result = service.GetAllTasks();

            //Assert 
            Xunit.Assert.NotEmpty(result);
        }
        [Fact]
        public void TestGetByIdSucsess()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<TaskEnt, TaskViewModel>().ReverseMap();
                x.CreateMap<TaskEnt, TaskAddModel>().ReverseMap();
                //x.CreateMap<Task,TaskUpdateModel>().ReverseMap();
            });
            Mapper mapper = new Mapper(configuration);
            TaskCrudOperations service = new TaskCrudOperations(dbContext, mapper);

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
                    Salary = 700.50m
                }
            };

            var addmodel = new TaskAddModel()
            {
                Title = "FirstTask",
                Description = "Complete a Task",
                AssigneeIds = new List<string> { employees[0].Id, employees[1].Id },
                DueDate = new DateTime(2024, 12, 03),
                IsCompleted = false
            };
            //Act
            var res = service.CreateTask(addmodel);
            TaskViewModel result = service.GetById(res.Id);

            //Assert 
            Xunit.Assert.Equal(res.IsCompleted, result.IsCompleted);
        }
        [Fact]
        public void TestCreateTaskSucsess()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<TaskEnt, TaskViewModel>().ReverseMap();
                x.CreateMap<TaskEnt, TaskAddModel>().ReverseMap();
                x.CreateMap<Employee,EmployeeAddModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            });
            Mapper mapper = new Mapper(configuration);
            TaskCrudOperations service = new TaskCrudOperations(dbContext, mapper);
            EmployeeCrudOperations meetingCrud = new EmployeeCrudOperations(dbContext, mapper);

            var employee = new EmployeeAddModel
            {
                FullName = "Dio Brando",
                Email = "dio@hotmail.com",
                Birthday = DateTime.Today,
                PhoneNumber = "0881238979",
                Salary = 500.99m,
            };
           var EmployeeID = meetingCrud.CreateEmployee(employee).Id;


            var addmodel = new TaskAddModel()
            {
                Title = "FirstTask",
                Description = "Complete a Task",
                AssigneeIds = new List<string> {EmployeeID},
                DueDate = new DateTime(2024, 12, 03),
                IsCompleted = false
            };
            //Act
            var res = service.CreateTask(addmodel);

            //Assert 
            Xunit.Assert.Equal(res.Title, addmodel.Title);
            Xunit.Assert.Equal(res.Assignees.FirstOrDefault().Id, addmodel.AssigneeIds.FirstOrDefault());
        }
        [Fact]
        public void UpdateTaskSuccesss()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<TaskEnt, TaskViewModel>().ReverseMap();
                x.CreateMap<TaskEnt, TaskAddModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeAddModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            });
            Mapper mapper = new Mapper(configuration);
            TaskCrudOperations service = new TaskCrudOperations(dbContext, mapper);
            EmployeeCrudOperations employeeCrud = new EmployeeCrudOperations(dbContext, mapper);

            var employees = new List<EmployeeAddModel>
            {
                new EmployeeAddModel()
                {
                    FullName = "Dio Brando",
                    Email = "dio@hotmail.com",
                    Birthday = DateTime.Today,
                    PhoneNumber = "0881238979",
                    Salary = 500.99m,
                },
                new EmployeeAddModel()
                {
                    FullName = "Jotaro Kujo",
                    Email = "jotaro@gmail.com",
                    Birthday = DateTime.Today,
                    PhoneNumber = "0884567890",
                    Salary = 700.50m
                }
            };
            var id1 = employeeCrud.CreateEmployee(employees[0]).Id;
            var id2 = employeeCrud.CreateEmployee(employees[1]).Id;


            var addmodel = new TaskAddModel()
            {
                Title = "FirstTask",
                Description = "Complete a Task",
                AssigneeIds = new List<string> {id1 },
                DueDate = new DateTime(2024, 12, 03),
                IsCompleted = false
            };
            var res = service.CreateTask(addmodel);
            var updatemodel = new TaskUpdateModel()
            {
                Id = res.Id,
                Title = "FirstTAsk",
                Description = "Complete the Task",
                AssigneeIds = new List<string>() {id1,id2},
                DueDate = new DateTime(2023, 12, 03),
                IsCompleted = true
            };
            //Act
            var result = service.UpdateTask(updatemodel);

            //Assert 
            Xunit.Assert.Equal(result.Title, updatemodel.Title);
            Xunit.Assert.Equal(result.IsCompleted, updatemodel.IsCompleted);
            Xunit.Assert.Equal(result.Assignees.FirstOrDefault(e =>e.Id == id2).Id, updatemodel.AssigneeIds.FirstOrDefault(id => id == id2));
        }
        [Fact]
        public void DeleteTaskSuccsess()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<TaskEnt, TaskViewModel>().ReverseMap();
                x.CreateMap<TaskEnt, TaskAddModel>().ReverseMap();
                x.CreateMap<Task, TaskUpdateModel>().ReverseMap();
            });
            Mapper mapper = new Mapper(configuration);
            TaskCrudOperations service = new TaskCrudOperations(dbContext, mapper);

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
                    Salary = 700.50m
                }
            };

            var addmodel = new TaskAddModel()
            {
                Title = "FirstTask",
                Description = "Complete a Task",
                AssigneeIds = new List<string> { employees[0].Id, employees[1].Id },
                DueDate = new DateTime(2024, 12, 03),
                IsCompleted = false
            };
            var res = service.CreateTask(addmodel);
            var deletemodel = new TaskDeleteModel()
            {
                Id = res.Id
            };
            //Act
            var result = service.DeleteTask(deletemodel);

            //Assert 
            Xunit.Assert.Equal("Success",result);
        }
    }
}
