﻿using EmployeeTask.Models.Entities.TaskModels;
using EmployeeTask_Services.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask_Services.Cruds
{
    internal class TaskCrudOperations : ITaskCrudOperations
    {
        public ICollection<TaskViewModel> GetAllTasks()
        {
            return new List<TaskViewModel>();
        }
        public TaskViewModel GetById(string id)
        {
            return new TaskViewModel();
        }
        public string CreateTask(TaskAddModel addModel)
        {
            return "Ye";
        }
        public string UpdateTask(TaskUpdateModel updateModel)
        {
            return "Ye";
        }
        public string DeleteTask(string id)
        {
            return "Ye";
        }
    }
}
