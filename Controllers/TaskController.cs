using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repository;
using TaskManagmentSystem.ViewModel;

namespace TaskManagmentSystem.Controllers
{
    
    public class TaskController : Controller
    {
        readonly ITaskRepository _taskRepository;
        readonly IMapper _mapper;

        public TaskController(ITaskRepository taskRepository , IMapper mapper){
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult index() {
            //view all Tasks
            var task = _taskRepository.getAllTasks();
            
            return Ok(_mapper.Map<IEnumerable<TaskView>>(task));
        }

        [HttpGet]
         public IActionResult getTask(int id) {
            //view specific Task by id
            var task = _taskRepository.getTaskById(id);
             return Ok(_mapper.Map<TaskView>(task));

         }

        [HttpPost]
        public IActionResult create([FromBody]TaskView newTask) {
            //[FromBody]-> because the task attributes declaring in body in the postman
           
            var task = _mapper.Map<Tasks>(newTask);  //it will map object from TaskView into Tasks 
            _taskRepository.createTask(task);
            return Ok(task);
        }

        [HttpDelete]
        public IActionResult delete(int id) {
            //to delete specific task by id
            var task = _taskRepository.getTaskById(id);
            if (task == null) return NotFound();
            _taskRepository.delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult update(int id,[FromBody]TaskView updatedTask) {
            //to update any attribute in task by id
            var task = _taskRepository.getTaskById(id);
            if (task == null) return NotFound();
            _mapper.Map(updatedTask, task);

            return Ok(_mapper.Map<TaskView>(task));
        }
   
 
    
    }
}
