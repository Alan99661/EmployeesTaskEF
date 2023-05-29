using AutoMapper;
using EmployeeTask.Database;
using EmployeeTask.Models.Entities.MeetingModels;
using EmployeeTask_Services.Constracts;
using Microsoft.EntityFrameworkCore;
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
            var list =_context.Meeting
                    .Select(m =>m)
                    .Include(m =>m.Attendees)
                    .ToList();
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
                var meeting = _context.Meeting
                    .Include(m =>m.Attendees)
                    .FirstOrDefault(m => m.Id == id);
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
                var employees = _context.Employees
                    .Where(e => addModel.AttendeeIds.Contains(e.Id))
                    .ToList();
                var meeting = _mapper.Map<Meeting> (addModel);
                meeting.Attendees = employees;
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
        public MeetingViewModel UpdateMeeting(MeetingUpdateModel updateModel)
        {
            try
            {
                var employees = _context.Employees
                    .Where(e => updateModel.AttendeeIds.Contains(e.Id))
                    .ToList();
                var meeting = _context.Meeting.FirstOrDefault(x => x.Id == updateModel.Id);

                meeting.Attendees = employees;
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
        public string DeleteMeeting(MeetingDeleteModel deleteModel)
        {
            try
            {
                var deletedEnt = _context.Meeting.FirstOrDefault(x => x.Id == deleteModel.Id);

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
