using AutoMapper;
using EmployeeTask.Database;
using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask.Models.Entities.TaskModels;
using EmployeeTask_Services.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask_Services.InfrastructureClasses
{
    public class SelectMeetingUpdateModel : ISelectMeetingUpdateModel
    {
        private readonly EmployeeTaskDbContext _employeeTaskDbContext;
        private readonly IMapper _mapper;

        public SelectMeetingUpdateModel(EmployeeTaskDbContext employeeTaskDbContext, IMapper mapper)
        {
            _employeeTaskDbContext = employeeTaskDbContext;
            _mapper = mapper;
        }

        public MeetingUpdateModel SelectMeetingUpdateM(string id)
        {
            var res = _employeeTaskDbContext.Meeting.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<MeetingUpdateModel>(res);
        }
    }
}
