using EmployeeTask.Models.Entities.TaskModels;

namespace EmployeeTask_Services.Constracts
{
    internal interface ITaskCrudOperations
    {
        TaskViewModel CreateTask(TaskAddModel addModel);
        string DeleteTask(TaskDeleteModel deleteModel);
        ICollection<TaskViewModel> GetAllTasks();
        TaskViewModel GetById(string id);
        TaskViewModel UpdateTask(TaskUpdateModel updateModel);
    }
}