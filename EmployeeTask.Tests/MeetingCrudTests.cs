using AutoMapper;
using EmployeeTask.Database;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask.Models.Entities.TaskModels;
using EmployeeTask_Services.Constracts;
using EmployeeTask_Services.Cruds;
using EmployeeTask_Services.InfrastructureClasses;
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
            ILoggerService logger = new LoggerService();
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
                    AssingnedTasks = new List<TaskEnt>() {}
                }
            };

            var addmodel = new MeetingAddModel()
            {
                Attendees = new List<Employee> { employees[0], employees[1] },
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
            ILoggerService logger = new LoggerService();
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
                    AssingnedTasks = new List<TaskEnt>() {}
                }
            };

            var addmodel = new MeetingAddModel()
            {
                Attendees = new List<Employee> { employees[0], employees[1] },
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
            ILoggerService logger = new LoggerService();
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
                    AssingnedTasks = new List<TaskEnt>() {}
                }
            };

            var addmodel = new MeetingAddModel()
            {
                Attendees = new List<Employee> { employees[0], employees[1] },
                StartTime = new DateTime(2023, 5, 30, 12, 00, 00),
                EndTime = new DateTime(2023, 5, 30, 12, 30, 00),
                Subject = "Ted Talk"
            };
            //Act
            var res = service.CreateMeeting(addmodel);

            //Assert 
            Xunit.Assert.Equal(res.Subject, addmodel.Subject);
            Xunit.Assert.Equal(res.Attendees, addmodel.Attendees);
            Xunit.Assert.Equal(res.Subject, addmodel.Attendees.FirstOrDefault().AttendedMeetings.FirstOrDefault().Subject);
        }

        [Fact]
        public void TestUpdateSuccsess()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            ILoggerService logger = new LoggerService();
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Meeting, MeetingViewModel>().ReverseMap();
                x.CreateMap<Meeting, MeetingAddModel>().ReverseMap();
                x.CreateMap<Meeting, MeetingUpdateModel>().ReverseMap();
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
                    AssingnedTasks = new List<TaskEnt>() {}
                }
            };

            var addmodel = new MeetingAddModel()
            {
                Attendees = new List<Employee> { employees[0], employees[1] },
                StartTime = new DateTime(2023, 5, 30, 12, 00, 00),
                EndTime = new DateTime(2023, 5, 30, 12, 30, 00),
                Subject = "Ted Talk"
            };

            var updatemodel = new MeetingUpdateModel()
            {
                Attendees = new List<Employee> { employees[1] },
                StartTime = new DateTime(2023, 5, 30, 12, 00, 00),
                EndTime = new DateTime(2023, 5, 30, 12, 30, 00),
                Subject = "Ted Talk"
            };
            //Act
            var id = service.CreateMeeting(addmodel).Id;
            var res = service.UpdateMeeting(id, updatemodel);

            //Assert 
            Xunit.Assert.Equal(res.Subject, updatemodel.Subject);
            Xunit.Assert.Equal(res.Attendees, updatemodel.Attendees);
        }

        [Fact]
        public void TestDeleteSuccsess()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            ILoggerService logger = new LoggerService();
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
                    AssingnedTasks = new List<TaskEnt>() {}
                }
            };

            var addmodel = new MeetingAddModel()
            {
                Attendees = new List<Employee> { employees[0], employees[1] },
                StartTime = new DateTime(2023, 5, 30, 12, 00, 00),
                EndTime = new DateTime(2023, 5, 30, 12, 30, 00),
                Subject = "Ted Talk"
            };
            //Act
            var id = service.CreateMeeting(addmodel).Id;
            var res = service.DeleteMeeting(id);

            //Assert 
            Xunit.Assert.Equal("Success", res);
        }
    }
}
