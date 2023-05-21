using EmployeeTask.Models.Entities.EmpyoyeeModels;

namespace EmployeeTask_Services.Constracts
{
    public interface IEmployeeCrudOperations
    {
        string CreateEmployee(EmployeeAddModel addModel);
        string DeleteEmployee(string id);
        ICollection<EmployeeViewModel> GetAllEmployees();
        EmployeeViewModel GetById(string id);
        string UpdateEmployee(EmployeeUpdateModel updateModel);
    }
}