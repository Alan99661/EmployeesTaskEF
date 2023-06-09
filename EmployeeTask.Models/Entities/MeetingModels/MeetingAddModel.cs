﻿using EmployeeTask.Models.Entities.EmpyoyeeModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models.Entities.MeetingModels
{
    public class MeetingAddModel
    {
        public string Subject { get; set; }
        public List<string> AttendeeIds { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
