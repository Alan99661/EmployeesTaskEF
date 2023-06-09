﻿using EmployeeTask.Models.Entities.EmpyoyeeModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models.Entities.MeetingModels
{
    public class MeetingViewModel
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public List<Employee> Attendees { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get;set; }
    }
}
