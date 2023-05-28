using EmployeeTask.Models.Entities.EmpyoyeeModels;

namespace EmployeeTask_Services.Constracts
{
    public interface IEmployeeCrudOperations
    {
        EmployeeViewModel CreateEmployee(EmployeeAddModel addModel);
        string DeleteEmployee(EmployeeDeleteModel deleteModel);
        ICollection<EmployeeViewModel> GetAllEmployees();
        EmployeeViewModel GetById(string id);
        EmployeeViewModel UpdateEmployee(EmployeeUpdateModel updateModel);
    }
}