using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    public class TasksCategoriesRepository : ITaskCategoriesRepository
    {

        TaskManagmentSystemContext _context;

        public TasksCategoriesRepository(TaskManagmentSystemContext context)
        {
            _context = context;
        }

        public TasksCategories createTasksCategories(TasksCategories newTasksCategories)
        {
            _context.TasksCategories.Add(newTasksCategories);
            _context.SaveChanges();
            return newTasksCategories;
        }

        public TasksCategories delete(int id)
        {
            TasksCategories taskCategory = _context.TasksCategories.Find(id);
            if (taskCategory != null)
            {
                _context.TasksCategories.Remove(taskCategory);
                _context.SaveChanges();
            }
            return taskCategory;
        }

        public IEnumerable<TasksCategories> getAllTasksCategories()
        {
            return _context.TasksCategories;
        }

        public TasksCategories getTaskCategoriesById(int id)
        {
            TasksCategories taskCategory = _context.TasksCategories.Find(id);
            return taskCategory;
        }

        public TasksCategories update(TasksCategories updatedTasksCategories)
        {
            var taskCategory = _context.TasksCategories.Attach(updatedTasksCategories);
            taskCategory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedTasksCategories;
        }
    }
}
