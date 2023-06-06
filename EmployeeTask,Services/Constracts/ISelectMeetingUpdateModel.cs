using EmployeeTask.Models.Entities.MeetingModels;

namespace EmployeeTask_Services.Constracts
{
    public interface ISelectMeetingUpdateModel
    {
        MeetingUpdateModel SelectMeetingUpdateM(string id);
    }
}