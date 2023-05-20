using EmployeeTask.Models.Contracts;
using System.Runtime.Intrinsics.X86;

namespace EmployeeTask.Models.Abstactions
{
    public class BaseModel : IBaseModel
    {
        public BaseModel() 
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get;internal set; }
    }
}