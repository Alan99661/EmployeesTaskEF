using EmployeeTask.Models.Entities.TaskModels;

namespace EmployeeTask_Services.Constracts
{
    public interface ISelectTaskUpdateModel
    {
        TaskUpdateModel SelectUpdateModel(string id);
    }
}