using AutoMapper;
using EmployeeTask.Database;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask_Services.Constracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask_Services.InfrastructureClasses
{
    public class EmployeeModelGetAll : IEmployeeModelGetAll
    {
        private readonly EmployeeTaskDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeModelGetAll(EmployeeTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<EmployeeSelectModel> GetAll()
        {
            var employees = _context.Employees.Select(s => s).ToList();
            var result = _mapper.Map<List<EmployeeSelectModel>>(employees);

            return result;
        }
    }
}
