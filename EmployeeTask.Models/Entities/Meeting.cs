using EmployeeTask.Models.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models.Entities
{
    public class Meeting : BaseModel
    {
        public Meeting() 
        {
            Duration = EndTime - StartTime;
        }
        public string Subject { get; set; }
        public List<Employee> Atendees { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; private set; }
    }
}
