using Microsoft.AspNetCore.Mvc;
using EmployeeTask_Services.Constracts;
using EmployeeTask.Models.Entities.TaskModels;
using System.Threading.Tasks;
using EmployeeTask.Models.Entities.EmpyoyeeModels;

namespace EmployeeTask.MVC.Controllers
{
    public class TaskController : Controller
	{
		private readonly ITaskCrudOperations operations;
		private readonly ISelectTaskUpdateModel getTaskUpdate;
		
		public TaskController(ITaskCrudOperations operations, ISelectTaskUpdateModel getTaskUpdate)
		{
			this.operations = operations;
			this.getTaskUpdate = getTaskUpdate;
		}

		public IActionResult Index()
		{
			var tasks = operations.GetAllTasks();
			return View(tasks);
		}
		public IActionResult GetById(string id)
		{
			var task = operations.GetById(id);
			return View(task);
		}
		public IActionResult CreateTask()
		{
			return View();
		}
		public IActionResult CreateTaskPost(TaskAddModel model)
		{
			if (!ModelState.IsValid)
            {
                return View(model);
            }
       
			var task = operations.CreateTask(model);
			return Redirect("/Task/GetById/" + task.Id);
		}
		public IActionResult UpdateTask(string id)
		{
			var task = getTaskUpdate.SelectUpdateModel(id);
			return View(task);
		}
		public IActionResult UpdateTaskPost(TaskUpdateModel model)
		{
			if (!ModelState.IsValid)
            {
                return View(model);
            }
       
			var task = operations.UpdateTask(model);
			return Redirect(("/Task/GetById/" + task.Id));
		}
		public IActionResult DeleteTask()
		{
			return View();
		}
		public IActionResult DeleteTaskPost(TaskDeleteModel model)
		{
			if (!ModelState.IsValid)
            {
                return View(model);
            }
       
			operations.DeleteTask(model);
			return RedirectToAction("Index");
		}
	}
}
