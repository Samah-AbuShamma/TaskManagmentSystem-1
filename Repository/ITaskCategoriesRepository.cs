using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
   public interface ITaskCategoriesRepository
    {
        public TasksCategories createTasksCategories(TasksCategories newTasksCategories);
        public TasksCategories delete(int id);
        public TasksCategories getTaskCategoriesById(int id);
        public TasksCategories update(TasksCategories updatedTasksCategories);
        public IEnumerable<TasksCategories> getAllTasksCategories();
    }
}
