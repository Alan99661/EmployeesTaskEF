using AutoMapper;
using EmployeeTask.Database;
using EmployeeTask.Models.Entities.TaskModels;
using EmployeeTask_Services.Constracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask_Services.Cruds
{
    public class TaskCrudOperations : ITaskCrudOperations
    {
        private readonly EmployeeTaskDbContext _context;
        private readonly IMapper _mapper;

        public TaskCrudOperations(EmployeeTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<TaskViewModel> GetAllTasks()
        {
            try
            {
                var taks = _context.Tasks
                    .Select(s => s)
                    .Include(s => s.Assignees)
                    .ToList();

                return _mapper.Map<List<TaskViewModel>>(taks);
            }
            catch(Exception ex)
            {
                throw new Exception("Failure");
            }
        }
        public TaskViewModel GetById(string id)
        {
            try
            {
                var task = _context.Tasks
                    .Include(s => s.Assignees)
                    .FirstOrDefault(s => s.Id == id);

                return _mapper.Map<TaskViewModel>(task);
            }
            catch(Exception ex)
            {
                throw new Exception("Failure");
            }
        }
        public TaskViewModel CreateTask(TaskAddModel addModel)
        {
            try
            {
                var employees = _context.Employees
                    .Where(e => addModel.AssigneeIds.Contains(e.Id))
                    .ToList();
                var task = _mapper.Map<TaskEnt>(addModel);
                task.Assignees = employees;
                _context.Add(task);
                _context.SaveChanges();

                return _mapper.Map<TaskViewModel>(task);
            }
            catch (Exception ex)
            {
                throw new Exception("Failure");
            }
        }
        public TaskViewModel UpdateTask(TaskUpdateModel updateModel)
        {
            try
            {
                var task = _context.Tasks.FirstOrDefault(s => s.Id == updateModel.Id);
                var employees = _context.Employees
                    .Where(e => updateModel.AssigneeIds.Contains(e.Id))
                    .ToList();

                task.DueDate = updateModel.DueDate;
                task.Description = updateModel.Description;
                task.Title = updateModel.Title;
                task.Assignees = employees;
                task.IsCompleted = updateModel.IsCompleted;

                _context.Update(task);
                _context.SaveChanges();
                return _mapper.Map<TaskViewModel>(task);
            }
            catch (Exception ex)
            {
                throw new Exception("Failure");
            }
        }
        public string DeleteTask(TaskDeleteModel deleteModel)
        {
            try
            {
            var task = _context.Tasks.FirstOrDefault(s => s.Id == deleteModel.Id);
            _context.Tasks.Remove(task);
            _context.SaveChanges(true);
                return "Success";
            }
            catch(Exception ex)
            {
                throw new Exception("Failure");
            }
        }
    }
}
