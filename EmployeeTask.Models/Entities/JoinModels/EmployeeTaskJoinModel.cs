using EmployeeTask.Models.Abstactions;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models.Entities.JoinModels
{
    public class EmployeeTaskJoinModel : BaseModel
    {
        public Task Task { get; set; }
        public Employee Employee { get; set; }
        public string TaskId { get; set; }
        public string EmployeeId { get; set; }
    }
}
