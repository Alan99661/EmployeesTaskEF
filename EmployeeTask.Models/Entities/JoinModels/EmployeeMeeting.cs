using EmployeeTask.Models.Abstactions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models.Entities.JoinModels
{
    public class EmployeeMeeting : BaseModel
    {
        public string EmployeeId { get; set; }
        public string MeetingId { get; set; }
    }
}
