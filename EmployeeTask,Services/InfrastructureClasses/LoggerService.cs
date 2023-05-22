using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTask_Services.Constracts;

namespace EmployeeTask_Services.InfrastructureClasses
{
    public class LoggerService : ILoggerService
    {
        public string Log(int option)
        {
            if (option == 0)
            {
                return "Failed";
            }
            return "Success";
        }
        public string CheckingNullMessage(IEnumerable<Object> objects)
        {
            if (objects == null)
            {
                return "Failed";
            }
            return "Success";

        }
        public string CheckNullMessageForSingleItem(Object item)
        {
            if (item == null)
            {
                return "Invalid Id";
            }
            return "Success";

        }
    }
}
