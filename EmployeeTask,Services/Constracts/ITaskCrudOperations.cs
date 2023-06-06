using EmployeeTask.Models.Entities.TaskModels;

namespace EmployeeTask_Services.Constracts
{
    public interface ITaskCrudOperations
    {
        public TaskViewModel CreateTask(TaskAddModel addModel);
        public string DeleteTask(TaskDeleteModel deleteModel);
        public ICollection<TaskViewModel> GetAllTasks();
        public TaskViewModel GetById(string id);
        public TaskViewModel UpdateTask(TaskUpdateModel updateModel);
    }
}