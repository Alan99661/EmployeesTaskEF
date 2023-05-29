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
    public class MeetingCrudTests
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
                x.CreateMap<Meeting, MeetingViewModel>().ReverseMap();
                x.CreateMap<Meeting, MeetingAddModel>().ReverseMap();

            });
            Mapper mapper = new Mapper(configuration);
            MeetingCrudOperations service = new MeetingCrudOperations(dbContext, mapper);

            var employees = new List<Employee>
            {
                new Employee()
                {
                    FullName = "Speedwagon",
                    Email = "speedwagon@hotmail.com",
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
                }
            };

            var addmodel = new MeetingAddModel()
            {
                AttendeeIds = new List<string> { employees[0].Id, employees[1].Id },
                StartTime = new DateTime(2023, 5, 30, 12, 00, 00),
                EndTime = new DateTime(2023, 5, 30, 12, 30, 00),
                Subject = "Ted Talk"
            };
            //Act
            service.CreateMeeting(addmodel);
            var result = service.GetAllMeetings();

            //Assert 
            Xunit.Assert.NotEmpty(result);
        }

        [Fact]
        public void TestGetByIdSuccsess()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Meeting, MeetingViewModel>().ReverseMap();
                x.CreateMap<Meeting, MeetingAddModel>().ReverseMap();
                //x.CreateMap<Employee, EmployeeDeleteModel>();
                //x.CreateMap<Employee, EmployeeUpdateModel>();

            });
            Mapper mapper = new Mapper(configuration);
            MeetingCrudOperations service = new MeetingCrudOperations(dbContext, mapper);

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
                }
            };

            var addmodel = new MeetingAddModel()
            {
                AttendeeIds = new List<string> { employees[0].Id, employees[1].Id },
                StartTime = new DateTime(2023, 5, 30, 12, 00, 00),
                EndTime = new DateTime(2023, 5, 30, 12, 30, 00),
                Subject = "Ted Talk"
            };
            //Act
            var id = service.CreateMeeting(addmodel).Id;
            var res = service.GetById(id);

            //Assert 
            Xunit.Assert.Equal(res.Subject, addmodel.Subject);
        }
        [Fact]
        public void TestCreateSuccsess()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Meeting, MeetingViewModel>().ReverseMap();
                x.CreateMap<Meeting, MeetingAddModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeAddModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeViewModel>().ReverseMap();

            });
            Mapper mapper = new Mapper(configuration);
            MeetingCrudOperations service = new MeetingCrudOperations(dbContext, mapper);
            EmployeeCrudOperations employeeCrudOperations = new EmployeeCrudOperations(dbContext, mapper);

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
           var id1 =employeeCrudOperations.CreateEmployee(employees[0]).Id;
           var id2 = employeeCrudOperations.CreateEmployee(employees[1]).Id;


            var addmodel = new MeetingAddModel()
            {
                AttendeeIds = new List<string> { id1, id2 },
                StartTime = new DateTime(2023, 5, 30, 12, 00, 00),
                EndTime = new DateTime(2023, 5, 30, 12, 30, 00),
                Subject = "Ted Talk"
            };
            //Act
            var res = service.CreateMeeting(addmodel);

            //Assert 
            Xunit.Assert.Equal(res.Subject, addmodel.Subject);
            Xunit.Assert.NotEmpty(res.Attendees);
            Xunit.Assert.Equal(res.Attendees.FirstOrDefault().Id, id1);
        }

        [Fact]
        public void TestUpdateSuccsess()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Meeting, MeetingViewModel>().ReverseMap();
                x.CreateMap<Meeting, MeetingAddModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeAddModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            });
            Mapper mapper = new Mapper(configuration);
            MeetingCrudOperations service = new MeetingCrudOperations(dbContext, mapper);
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
            var id1 = employeeCrud.CreateEmployee(employees[1]).Id;
            var id2 = employeeCrud.CreateEmployee(employees[0]).Id;


            var addmodel = new MeetingAddModel()
            {
                AttendeeIds = new List<string> { id1, id2 },
                StartTime = new DateTime(2023, 5, 30, 12, 00, 00),
                EndTime = new DateTime(2023, 5, 30, 12, 30, 00),
                Subject = "Ted Talk"
            };
            var id = service.CreateMeeting(addmodel).Id;

            var updatemodel = new MeetingUpdateModel()
            {
                Id = id,
                AttendeeIds = new List<string> { id1 },
                StartTime = new DateTime(2023, 5, 30, 12, 00, 00),
                EndTime = new DateTime(2023, 5, 30, 12, 30, 00),
                Subject = "Ted Talk"
            };
            //Act
            var res = service.UpdateMeeting(updatemodel);

            //Assert 
            Xunit.Assert.Equal(res.Subject, updatemodel.Subject);
        }

        [Fact]
        public void TestDeleteSuccsess()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Meeting, MeetingViewModel>().ReverseMap();
                x.CreateMap<Meeting, MeetingAddModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeAddModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeViewModel>().ReverseMap();

            });
            Mapper mapper = new Mapper(configuration);
            MeetingCrudOperations service = new MeetingCrudOperations(dbContext, mapper);
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
                    Salary = 700.50m,
                    AssignedTasks = new List<TaskEnt>() {}
                }
            };
            var id1 = employeeCrud.CreateEmployee(employees[1]).Id;
            var id2 = employeeCrud.CreateEmployee(employees[0]).Id;

            var addmodel = new MeetingAddModel()
            {
                AttendeeIds = new List<string> {id1,id2},
                StartTime = new DateTime(2023, 5, 30, 12, 00, 00),
                EndTime = new DateTime(2023, 5, 30, 12, 30, 00),
                Subject = "Ted Talk"
            };
            var id = service.CreateMeeting(addmodel).Id;
            var deleteModel = new MeetingDeleteModel()
            {
                Id = id
            };
            {            //Act
                var res = service.DeleteMeeting(deleteModel);

                //Assert 
                Xunit.Assert.Equal("Success", res);
            }
        }
    }
}
