using EmployeeTask.Models.Entities.TaskModels;

namespace EmployeeTask_Services.Constracts
{
    internal interface ITaskCrudOperations
    {
        string CreateTask(TaskAddModel addModel);
        string DeleteTask(string id);
        ICollection<TaskViewModel> GetAllTasks();
        TaskViewModel GetById(string id);
        string UpdateTask(TaskUpdateModel updateModel);
    }
}