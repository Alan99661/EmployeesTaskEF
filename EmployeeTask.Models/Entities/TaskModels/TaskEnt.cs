using EmployeeTask.Models.Abstactions;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models.Entities.TaskModels
{
    public class TaskEnt : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<Employee> Assingnees { get; set; }
        public bool IsCompleted { get; set; }
    }
}
