using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask_Services.Constracts;
using EmployeeTask_Services.Cruds;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTask.MVC.Controllers
{

	public class MeetingController : Controller
	{

		private readonly IMeetingCrudOperations operations;

		public MeetingController(IMeetingCrudOperations operations)
		{
			this.operations = operations;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetById(string id)
		{
			return View();
		}
		public IActionResult CreateMeeting()
		{
			return View();
		}
		public IActionResult CreateMeetingPost(MeetingAddModel model)
		{
			var task = operations.CreateMeeting(model);
			return Redirect("/GetById/" + task.Id);
		}
		public IActionResult UpdateMeeting() 
		{
			return View();
		}
		public IActionResult UpdateMeetingPost(MeetingUpdateModel model)
		{
			var task = operations.UpdateMeeting(model);
			return Redirect("/GetById/" + task.Id);
		}
		public IActionResult DeleteMeeting() 
		{
			return View();
		}
		public IActionResult DeleteMeetingPost(MeetingDeleteModel model)
		{
			operations.DeleteMeeting(model);
			return RedirectToAction("Index");
		}
	}
}
