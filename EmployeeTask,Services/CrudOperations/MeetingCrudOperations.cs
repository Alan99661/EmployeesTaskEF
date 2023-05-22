using AutoMapper;
using EmployeeTask.Database;
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
        private readonly EmployeeTaskDbContext _context;
        private readonly IMapper _mapper;

        public MeetingCrudOperations(EmployeeTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<MeetingViewModel> GetAllMeetings()
        {
            try
            {
            var list =_context.Meeting.Select(m =>m).ToList();
            var result =_mapper.Map<List<MeetingViewModel>>(list);
            return result;
            }
            catch (Exception ex)
            {
                 throw new Exception("Failed");
            }

        }
        public MeetingViewModel GetById(string id)
        {
            try
            {
                var meeting = _context.Meeting.FirstOrDefault(m => m.Id == id);
                var result = _mapper.Map<MeetingViewModel>(meeting);
                return result;
            }
            catch (Exception ex) 
            {
                throw new Exception("Failed");
            }
        }
        public MeetingViewModel CreateMeeting(MeetingAddModel addModel)
        {
            try
            {
                var meeting = _mapper.Map<Meeting> (addModel);
                _context.Meeting.Add(meeting);
                _context.SaveChanges();
                var result = _mapper.Map<MeetingViewModel>(meeting);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public MeetingViewModel UpdateMeeting(string id,MeetingUpdateModel updateModel)
        {
            try
            {
                var meeting = _context.Meeting.FirstOrDefault(x => x.Id == id);

                meeting.Attendees = updateModel.Attendees;
                meeting.StartTime = updateModel.StartTime;
                meeting.EndTime = updateModel.EndTime;
                meeting.Subject = updateModel.Subject;

                _context.Meeting.Update(meeting);
                _context.SaveChanges();

                return _mapper.Map<MeetingViewModel>(meeting);
            }
            catch(Exception e)
            {
                throw new Exception("Failed");
            }
        }
        public string DeleteMeeting(string id)
        {
            try
            {
                var deletedEnt = _context.Meeting.FirstOrDefault(x => x.Id == id);

                _context.Meeting.Remove(deletedEnt);
                _context.SaveChanges();

                return "Success";
            }
            catch (Exception e)
            {
                throw new Exception("Failed");
            }
        }
    }
}
