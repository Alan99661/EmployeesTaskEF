using EmployeeTask.Models.Entities.TaskModels;

namespace EmployeeTask_Services.Constracts
{
    internal interface ITaskCrudOperations
    {
        TaskViewModel CreateTask(TaskAddModel addModel);
        string DeleteTask(string id);
        ICollection<TaskViewModel> GetAllTasks();
        TaskViewModel GetById(string id);
        TaskViewModel UpdateTask(string id,TaskUpdateModel updateModel);
    }
}