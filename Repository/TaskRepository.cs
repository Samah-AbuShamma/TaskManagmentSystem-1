using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    public class TaskRepository : ITaskRepository
    {
        TaskManagmentSystemContext _context;

        public TaskRepository(TaskManagmentSystemContext context) {
            _context = context;
        }

        public Tasks createTask(Tasks newTask)
        {
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
            return newTask;
        }

        public Tasks delete(int id)
        {
            Tasks task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            return task;
        }

        public IEnumerable<Tasks> getAllTasks()
        {
           return _context.Tasks;
        }

        public Tasks getTaskById(int id)
        {
         Tasks task = _context.Tasks.Find(id);
            return task;
        }

        public Tasks update(Tasks updatedTask)
        {
            var task = _context.Tasks.Attach(updatedTask);
            task.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedTask;
        }
    }
}
