using AutoMapper;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask.Models.Entities.TaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Database.Configuring.Mapper
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeAddModel>().ReverseMap();
            CreateMap<Employee, EmployeeDeleteModel>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateModel>().ReverseMap();
            CreateMap<TaskEnt, TaskViewModel>().ReverseMap().ForMember(t => t.Assignees, opt => opt.Ignore());
            CreateMap<TaskEnt, TaskAddModel>().ReverseMap();
            CreateMap<TaskEnt, TaskUpdateModel>().ReverseMap();
            CreateMap<TaskEnt, TaskDeleteModel>().ReverseMap();
            CreateMap<Meeting,MeetingViewModel>().ReverseMap();
            CreateMap<Meeting,MeetingAddModel>().ReverseMap();
            CreateMap<Meeting, MeetingUpdateModel>().ReverseMap();
            CreateMap<Meeting,MeetingDeleteModel>().ReverseMap();

        }
    }
}
