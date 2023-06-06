using AutoMapper;
using EmployeeTask.Database;
using EmployeeTask.Models.Entities.TaskModels;
using EmployeeTask_Services.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask_Services.InfrastructureClasses
{
    public class SelectTaskUpdateModel : ISelectTaskUpdateModel
    {
        private readonly EmployeeTaskDbContext _context;
        private readonly IMapper _mapper;

        public SelectTaskUpdateModel(EmployeeTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TaskUpdateModel SelectUpdateModel(string id)
        {
            var res = _context.Tasks.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<TaskUpdateModel>(res);
        }
    }
}
