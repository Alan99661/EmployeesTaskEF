using Microsoft.AspNetCore.Mvc;
using EmployeeTask_Services.Constracts;
using EmployeeTask.Models.Entities.TaskModels;
using System.Threading.Tasks;

namespace EmployeeTask.MVC.Controllers
{
	public class TaskController : Controller
	{
		private readonly ITaskCrudOperations operations;
		private readonly IEmployeeSelect getAll;
		
		public TaskController(ITaskCrudOperations operations, IEmployeeSelect getAll)
		{
			this.operations = operations;
			this.getAll = getAll;
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
		public IActionResult GetEmployeeModels()
		{
			List<EmployeeSelectModel> models = getAll.GetAll();
			return Json(models);
		}
		public IActionResult CreateTaskPost(TaskAddModel model)
		{
			var task = operations.CreateTask(model);
			return Redirect("/GetById/" + task.Id);
		}
		public IActionResult UpdateTask() { return View(); }

		public IActionResult UpdateTaskPost(TaskUpdateModel model)
		{
			var task = operations.UpdateTask(model);
			return Redirect(("/GetById/" + task.Id));
		}
		public IActionResult DeleteTask()
		{
			return View();
		}
		public IActionResult DeleteTaskPost(TaskDeleteModel model)
		{
			operations.DeleteTask(model);
			return RedirectToAction("Index");
		}
	}
}
