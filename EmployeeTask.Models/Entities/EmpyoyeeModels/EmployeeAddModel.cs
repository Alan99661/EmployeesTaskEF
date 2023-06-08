using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask.Models.Entities.TaskModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please enter a valid 10-digit mobile number.")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<TaskEnt>? AssignedTasks { get; set; }
        public ICollection<Meeting>? Meetings { get; set; }
    }
}
