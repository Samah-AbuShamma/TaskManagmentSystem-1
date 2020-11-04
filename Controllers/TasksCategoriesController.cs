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
    public class TasksCategoriesController : Controller
    {


        readonly ITaskCategoriesRepository _taskCategoriesRepository;
        readonly IMapper _mapper;

        public TasksCategoriesController(ITaskCategoriesRepository taskCategoriesRepository, IMapper mapper)
        {
            _taskCategoriesRepository = taskCategoriesRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult index()
        {
            //view all Tasks Categories
            var taskCategory = _taskCategoriesRepository.getAllTasksCategories();

            return Ok(_mapper.Map<IEnumerable<TaskCategoriesView>>(taskCategory));
        }

        [HttpGet]
        public IActionResult getTaskCategory(int id)
        {
            //view specific Task category by id
            var taskCategory = _taskCategoriesRepository.getTaskCategoriesById(id);
            return Ok(_mapper.Map<TaskCategoriesView>(taskCategory));

        }

        [HttpPost]
        public IActionResult create([FromBody] TaskCategoriesView newTaskCategory)
        {
            //[FromBody]-> because the task category attributes declaring in body in the postman

            var taskCategory = _mapper.Map<TasksCategories>(newTaskCategory);  //it will map object from TaskCategoryView into TasksCategories 
            _taskCategoriesRepository.createTasksCategories(taskCategory);
            return Ok(taskCategory);
        }

        [HttpDelete]
        public IActionResult delete(int id)
        {
            //to delete specific task category by id
            var tasksCategory = _taskCategoriesRepository.getTaskCategoriesById(id);
            if (tasksCategory == null) return NotFound();
            _taskCategoriesRepository.delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult update(int id, [FromBody] TaskCategoriesView updatedTaskCategory)
        {
            //to update any attribute in task category by id
            var taskCategory = _taskCategoriesRepository.getTaskCategoriesById(id);
            if (taskCategory == null) return NotFound();
            _mapper.Map(updatedTaskCategory, taskCategory);

            return Ok(_mapper.Map<TaskCategoriesView>(taskCategory));
        }





    }
}
