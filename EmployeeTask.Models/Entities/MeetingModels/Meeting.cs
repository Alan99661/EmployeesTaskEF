using EmployeeTask.Models.Abstactions;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models.Entities.MeetingModels
{
    public class Meeting : BaseModel
    {
        public string Subject { get; set; }
        public ICollection<Employee> Attendees { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration => EndTime - StartTime;
    }
}
