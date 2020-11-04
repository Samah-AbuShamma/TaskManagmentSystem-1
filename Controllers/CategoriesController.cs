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
    public class CategoriesController : Controller
    {

        readonly ICategoriesRepository _categoriesRepository;
        readonly IMapper _mapper;

        public CategoriesController(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult index()
        {
            //view all Categories
            var category = _categoriesRepository.getAllCategories();

            return Ok(_mapper.Map<IEnumerable<CategoryView>>(category));
        }

        [HttpGet]
        public IActionResult getCategory(int id)
        {
            //view specific category by id
            var category = _categoriesRepository.getCategoryById(id);
            return Ok(_mapper.Map<CategoryView>(category));

        }

        [HttpPost]
        public IActionResult create([FromBody] CategoryView newCategory)
        {
            //[FromBody]-> because the Categories attributes declaring in body in the postman

            var category = _mapper.Map<Categories>(newCategory);  //it will map object from CategoryView into Categories 
            _categoriesRepository.createCategories(category);
            return Ok(category);
        }

        [HttpDelete]
        public IActionResult delete(int id)
        {
            //to delete specific category by id
            var category = _categoriesRepository.getCategoryById(id);
            if (category == null) return NotFound();
            _categoriesRepository.delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult update(int id, [FromBody] CategoryView updatedCategory)
        {
            //to update any attribute in category by id
            var category = _categoriesRepository.getCategoryById(id);
            if (category == null) return NotFound();
            _mapper.Map(updatedCategory, category);

            return Ok(_mapper.Map<CategoryView>(category));
        }




    }
}
