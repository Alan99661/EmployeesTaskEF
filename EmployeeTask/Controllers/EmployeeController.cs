using EmployeeTask.Database;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask_Services.Constracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTask.Controllers
{
    public class EmployeeController : Controller
    {
        ////private readonly IEmployeeCrudOperations _service;
        //public EmployeeController(IEmployeeCrudOperations service)
        //{
        //    _service = service;
        //}
        public IActionResult Index() 
        {
            return View();
        }

        //[HttpPost]
        public IActionResult CreateEmployee()
        {

            return View();
        }
    }
}
