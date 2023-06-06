using EmployeeTask.Models.Entities.TaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask_Services.Constracts
{
	public interface IEmployeeSelect
	{
		public List<EmployeeSelectModel> GetAll();
	}
}
