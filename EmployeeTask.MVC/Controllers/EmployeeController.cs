using EmployeeTask_Services.Constracts;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using Microsoft.AspNetCore.Mvc;
using EmployeeTask.Models.Entities.TaskModels;

namespace EmployeeTask.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeCrudOperations operations;
        private readonly IEmployeeModelGetAll getAll;
        public EmployeeController(IEmployeeCrudOperations operations, IEmployeeModelGetAll getAll)
        {
            this.operations = operations;
            this.getAll = getAll;
        }
        public IActionResult Index()
        {
            var Employees = operations.GetAllEmployees();
            return View(Employees);
        }

        public IActionResult CreateEmployee()
        { 
            return View("CreateNewEmployee");
        }
        public IActionResult CreateNewEmployee(EmployeeAddModel model)
        {
            var res = operations.CreateEmployee(model);
            return Redirect("/Employee/GetById/" + res.Id);
        }


        public IActionResult GetById(string id)
        {
            var res = operations.GetById(id);
            return View(res);
        }

        public IActionResult UpdateEmployee(string id)
        {
            var emp=operations.GetById(id);
            return View(emp);
        }
        public IActionResult UpdateEmployeePost(EmployeeUpdateModel updateModel)
        {
            var res = operations.UpdateEmployee(updateModel);
            return Redirect("/Employee/GetById/" + res.Id);
        }
        public IActionResult DeleteEmployee() 
        {
            return View();
        }
        public IActionResult DeleteEmployeePost(EmployeeDeleteModel deleteModel)
        {
            operations.DeleteEmployee(deleteModel);
            return RedirectToAction("Index");
        }
        public IActionResult GetEmployeeModels()
        {
            List<EmployeeSelectModel> models = getAll.GetAll();
            return Json(models);
        }
    }
}
