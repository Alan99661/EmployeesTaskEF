using AutoMapper;
using EmployeeTask.Database;
using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask_Services.Constracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask_Services.Cruds
{
    public class EmployeeCrudOperations : IEmployeeCrudOperations
    {
        private readonly EmployeeTaskDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeCrudOperations(EmployeeTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<EmployeeViewModel> GetAllEmployees()
        {

            var employees = _context.Employees.Select(s => s).Include(e=>e.Meetings).ToList();
            var result = _mapper.Map<List<EmployeeViewModel>>(employees);

            return result;
        }

        public EmployeeViewModel GetById(string id)
        {

            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            var result = _mapper.Map<EmployeeViewModel>(employee);

            return result;
        }

        public EmployeeViewModel CreateEmployee(EmployeeAddModel addModel)
        {
            try
            {

                var employeeEnt = _mapper.Map<Employee>(addModel);
                
               // _context.Meeting.FirstOrDefault(x => x.)
                _context.Employees.Add(employeeEnt);
                var result = _mapper.Map<EmployeeViewModel>(employeeEnt);
                _context.SaveChanges();

                return result;
            }
            catch (Exception ex) 
            {
                throw new Exception("Failure");
            }
        }

        public EmployeeViewModel UpdateEmployee(string id, EmployeeUpdateModel updateModel)
        {
            try
            {

                var employeeEnt = _context.Employees.FirstOrDefault(e =>e.Id == id);

                employeeEnt.FullName = updateModel.FullName;
                employeeEnt.Salary = updateModel.Salary;
                employeeEnt.PhoneNumber = updateModel.PhoneNumber;
                employeeEnt.Birthday = updateModel.Birthday;
                employeeEnt.Email = updateModel.Email;
                employeeEnt.Meetings = updateModel.Meetings;
                employeeEnt.AssignedTasks = updateModel.AssignedTasks;

                var res = _context.Employees.Update(employeeEnt);
                _context.SaveChanges();
                var result = _mapper.Map<EmployeeViewModel>(employeeEnt);
               
                return result;
          
            }
            catch(Exception ex)
            {
                throw new Exception("Failure");
            }
        }
        public string DeleteEmployee(string id)
        {
            try
            {

                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                _context.Employees.Remove(employee);
                _context.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return "Failure";
            }
        }
    }
}