using EmployeeTask.Models.Entities.MeetingModels;

namespace EmployeeTask_Services.Constracts
{
    internal interface IMeetingCrudOperations
    {
        string CreateMeeting(MeetingAddModel addModel);
        string DeleteMeeting(string id);
        ICollection<MeetingViewModel> GetAllMeetings();
        MeetingViewModel GetById(string id);
        string UpdateMeeting(MeetingUpdateModel updateModel);
    }
}