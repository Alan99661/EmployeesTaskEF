using EmployeeTask.Models.Entities.MeetingModels;

namespace EmployeeTask_Services.Constracts
{
    internal interface IMeetingCrudOperations
    {
        MeetingViewModel CreateMeeting(MeetingAddModel addModel);
        string DeleteMeeting(string id);
        ICollection<MeetingViewModel> GetAllMeetings();
        MeetingViewModel GetById(string id);
        MeetingViewModel UpdateMeeting(string id,MeetingUpdateModel updateModel);
    }
}