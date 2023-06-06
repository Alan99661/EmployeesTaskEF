using EmployeeTask.Models.Entities.EmpyoyeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask_Services.Constracts
{
    public interface IEmployeeModelGetAll
	{
		public List<EmployeeSelectModel> GetAll();
	}
}
