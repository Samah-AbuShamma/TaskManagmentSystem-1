using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    public interface ITaskRepository
    {
        public Tasks createTask(Tasks newTask);
        public Tasks delete(int id);
        public Tasks getTaskById(int id);
        public Tasks update(Tasks updatedTask);
        public IEnumerable<Tasks> getAllTasks();
        
    }
}
