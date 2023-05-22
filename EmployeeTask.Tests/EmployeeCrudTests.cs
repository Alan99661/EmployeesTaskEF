using AutoMapper;
using EmployeeTask.Database;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask_Services.Constracts;
using EmployeeTask_Services.Cruds;
using EmployeeTask_Services.InfrastructureClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Xunit;

namespace EmployeeTask.Tests
{
    [TestClass]
    public class EmployeeCrudTests
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
                x.CreateMap<Employee,EmployeeViewModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeAddModel>().ReverseMap();
                //x.CreateMap<Employee, EmployeeDeleteModel>();
                //x.CreateMap<Employee, EmployeeUpdateModel>();

            });
            Mapper mapper = new Mapper(configuration);
            EmployeeCrudOperations service = new EmployeeCrudOperations(dbContext,mapper);
            var addmodel = new EmployeeAddModel()
            {
                Birthday = new DateTime(2000, 10, 13),
                FullName = "TestManMcGee",
                Email = "tetsman@gmial.com",
                Salary = 1000.00m,
                PhoneNumber = "0872183711"
            };
            //Act
            service.CreateEmployee(addmodel);
            var result = service.GetAllEmployees();
            //Assert 
            Xunit.Assert.NotEmpty(result);      
        }
        [Fact]
        public void TestGetByIdSuccsess() 
        {
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
                      .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
                      .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            ILoggerService logger = new LoggerService();
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeAddModel>().ReverseMap();
                //x.CreateMap<Employee, EmployeeDeleteModel>();
               // x.CreateMap<Employee, EmployeeUpdateModel>().ReverseMap();

            });
            Mapper mapper = new Mapper(configuration);
            EmployeeCrudOperations service = new EmployeeCrudOperations(dbContext, mapper);
            var addmodel = new EmployeeAddModel()
            {
                Birthday = new DateTime(2000, 10, 13),
                FullName = "TestManMcGee",
                Email = "tetsman@gmial.com",
                Salary = 1000.00m,
                PhoneNumber = "0872183711"
            };
            //Act
            var id = service.CreateEmployee(addmodel).Id;
            var result = service.GetById(id);
            //Assert
            Xunit.Assert.Equal(addmodel.FullName, result.FullName);
        }
        [Fact]
        public void AddEmployeeSuccsess() 
        {
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            ILoggerService logger = new LoggerService();
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
                x.CreateMap<Employee,EmployeeAddModel>().ReverseMap();
                //x.CreateMap<Employee, EmployeeDeleteModel>();
                x.CreateMap<Employee, EmployeeUpdateModel>().ReverseMap();

            });
            Mapper mapper = new Mapper(configuration);
            EmployeeCrudOperations service = new EmployeeCrudOperations(dbContext, mapper);
            var addmodel = new EmployeeAddModel()
            {
                Birthday = new DateTime(2000, 10, 13),
                FullName = "TestManMcGee",
                Email = "tetsman@gmial.com",
                Salary = 1000.00m,
                PhoneNumber = "0872183711"
            };
            //Act
           var res = service.CreateEmployee(addmodel);
            //Assert
            Xunit.Assert.Equal(addmodel.FullName,res.FullName);
        }
        [Fact]
        public void UpdateEmployeeSuccess() 
        {
            //Arrange
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
           .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
           .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            ILoggerService logger = new LoggerService();
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
                x.CreateMap<Employee,EmployeeAddModel>().ReverseMap();
                //x.CreateMap<Employee, EmployeeDeleteModel>();
                x.CreateMap<Employee, EmployeeUpdateModel>().ReverseMap().ForMember(dest => dest.Id, act => act.Ignore()); 

            });
            Mapper mapper = new Mapper(configuration);
            EmployeeCrudOperations service = new EmployeeCrudOperations(dbContext, mapper);
            var updateModel = new EmployeeUpdateModel()
            {
                Birthday = new DateTime(2000, 10, 13),
                FullName = "TestManMcGuy",
                Email = "tetsman@hotmail.com",
                Salary = 1020.00m,
                PhoneNumber = "0882183711"
            };
            var addmodel = new EmployeeAddModel()
            {
                Birthday = new DateTime(2000, 10, 13),
                FullName = "TestManMcGee",
                Email = "tetsman@gmial.com",
                Salary = 1000.00m,
                PhoneNumber = "0872183711"
            };
            //Act
            string id = service.CreateEmployee(addmodel).Id;
            var res = service.UpdateEmployee(id,updateModel);
            //Assert 
            Xunit.Assert.Equal(updateModel.FullName,res.FullName);
        }
        [Fact]
        public void EmpoyeeDeleteSuccsess()
        {
            var options = new DbContextOptionsBuilder<EmployeeTaskDbContext>()
          .UseInMemoryDatabase(databaseName: "EmployeeTaskDb")
          .Options;
            EmployeeTaskDbContext dbContext = new EmployeeTaskDbContext(options);
            ILoggerService logger = new LoggerService();
            IConfigurationProvider configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
                x.CreateMap<Employee, EmployeeAddModel>().ReverseMap();
                //x.CreateMap<Employee, EmployeeDeleteModel>();
                //x.CreateMap<Employee, EmployeeUpdateModel>();

            });
            Mapper mapper = new Mapper(configuration);
            EmployeeCrudOperations service = new EmployeeCrudOperations(dbContext, mapper);
            var addmodel = new EmployeeAddModel()
            {
                Birthday = new DateTime(2000, 10, 13),
                FullName = "TestManMcGee",
                Email = "tetsman@gmial.com",
                Salary = 1000.00m,
                PhoneNumber = "0872183711"
            };
            //Act
            string id = service.CreateEmployee(addmodel).Id;
            var _res = service.DeleteEmployee(id);
            //Assert
            Xunit.Assert.Equal(_res, "Success");
        }
    }
}