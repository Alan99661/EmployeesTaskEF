using EmployeeTask.Models.Entities.EmpyoyeeModels;

namespace EmployeeTask_Services.Constracts
{
    public interface IEmployeeCrudOperations
    {
        EmployeeViewModel CreateEmployee(EmployeeAddModel addModel);
        string DeleteEmployee(string id);
        ICollection<EmployeeViewModel> GetAllEmployees();
        EmployeeViewModel GetById(string id);
        EmployeeViewModel UpdateEmployee(string id,EmployeeUpdateModel updateModel);
    }
}