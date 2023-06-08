using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask_Services.Constracts;
using EmployeeTask_Services.Cruds;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTask.MVC.Controllers
{

	public class MeetingController : Controller
	{

		private readonly IMeetingCrudOperations operations;
		private readonly ISelectMeetingUpdateModel selectMeetingUpdateModel;

		public MeetingController(IMeetingCrudOperations operations)
		{
			this.operations = operations;
		}

		public IActionResult Index()
		{
			var res = operations.GetAllMeetings();
			return View(res);
		}
		public IActionResult GetById(string id)
		{
			var res = operations.GetById(id);
			return View(res);
		}
		public IActionResult CreateMeeting()
		{
			return View();
		}
		public IActionResult CreateMeetingPost(MeetingAddModel model)
		{
			if (!ModelState.IsValid)
            {
                return View(model);
            }
       
			var task = operations.CreateMeeting(model);
			return Redirect("/Meeting/GetById/" + task.Id);
		}
		public IActionResult UpdateMeeting(string id) 
		{
			var res = selectMeetingUpdateModel.SelectMeetingUpdateM(id);
			return View(res);
		}
		public IActionResult UpdateMeetingPost(MeetingUpdateModel model)
		{
			if (!ModelState.IsValid)
            {
                return View(model);
            }
       
			var task = operations.UpdateMeeting(model);
			return Redirect("/Meeting/GetById/" + task.Id);
		}
		public IActionResult DeleteMeeting() 
		{
			return View();
		}
		public IActionResult DeleteMeetingPost(MeetingDeleteModel model)
		{
			if (!ModelState.IsValid)
            {
                return View(model);
            }
       
			operations.DeleteMeeting(model);
			return RedirectToAction("Index");
		}
	}
}
