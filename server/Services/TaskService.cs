using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface ITaskService
    {
       
        IEnumerable<Task> GetAll();
        Task Create(Task task);
        void Delete(int id);
        void UpdateTask(Task updateTask);
    }

    public class TaskService : ITaskService
    {
        private DataContext _context;

        public TaskService(DataContext context)
        {
            _context = context;
        }



        public IEnumerable<Task> GetAll()
        {
            return _context.Tasks;
        }
        public Task Create(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return task;
        }
        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public void UpdateTask(Task Update)
        {
            var task = _context.Tasks.Find(Update.Id);
            if (task != null)
            {
                _context.Tasks.Update(task);
                _context.SaveChanges();
            }
        }

    }
}