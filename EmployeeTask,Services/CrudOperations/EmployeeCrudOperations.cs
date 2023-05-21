using EmployeeTask.Models.Entities.EmpyoyeeModels;
using EmployeeTask_Services.Constracts;

namespace EmployeeTask_Services.Cruds
{
    public class EmployeeCrudOperations : IEmployeeCrudOperations
    {
        public ICollection<EmployeeViewModel> GetAllEmployees()
        {
            return new List<EmployeeViewModel>();
        }
        public EmployeeViewModel GetById(string id)
        {
            return new EmployeeViewModel();
        }
        public string CreateEmployee(EmployeeAddModel addModel)
        {
            return "Ye";
        }
        public string UpdateEmployee(EmployeeUpdateModel updateModel)
        {
            return "Ye";
        }
        public string DeleteEmployee(string id)
        {
            return "Ye";
        }
    }
}