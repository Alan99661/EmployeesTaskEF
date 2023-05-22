using EmployeeTask.Models.Abstactions;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models.Entities.JoinModels
{
    public class EmployeeTaskEnt : BaseModel
    {
        public string TaskId { get; set; }
        public string EmployeeId { get; set; }
        // public TaskEnt Task {get; set; }
        //public Empoyee Employee {get; set; }
    }
}
