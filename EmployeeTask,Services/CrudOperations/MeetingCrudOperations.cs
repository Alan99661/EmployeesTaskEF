using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask_Services.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask_Services.Cruds
{
    public class MeetingCrudOperations : IMeetingCrudOperations
    {
        public ICollection<MeetingViewModel> GetAllMeetings()
        {
            return new List<MeetingViewModel>();
        }
        public MeetingViewModel GetById(string id)
        {
            return new MeetingViewModel();
        }
        public string CreateMeeting(MeetingAddModel addModel)
        {
            return "Ye";
        }
        public string UpdateMeeting(MeetingUpdateModel updateModel)
        {
            return "Ye";
        }
        public string DeleteMeeting(string id)
        {
            return "Ye";
        }
    }
}
