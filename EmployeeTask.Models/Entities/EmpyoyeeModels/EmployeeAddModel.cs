using EmployeeTask.Models.Entities.TaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models.Entities.EmpyoyeeModels
{
    public class EmployeeAddModel
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<TaskEnt>? AssingnedTasks { get; set; }
    }
}
