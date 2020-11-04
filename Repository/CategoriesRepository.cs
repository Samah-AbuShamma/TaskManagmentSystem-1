using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        TaskManagmentSystemContext _context;

        public CategoriesRepository(TaskManagmentSystemContext context)
        {
            _context = context;
        }

        public Categories createCategories(Categories newCategories)
        {
            _context.Categories.Add(newCategories);
            _context.SaveChanges();
            return newCategories;
        }

        public Categories delete(int id)
        {
            Categories categories = _context.Categories.Find(id);
            if (categories != null)
            {
                _context.Categories.Remove(categories);
                _context.SaveChanges();
            }
            return categories;
    }

        public IEnumerable<Categories> getAllCategories()
        {
            return _context.Categories;
        }

        public Categories getCategoryById(int id)
        {
            Categories categories = _context.Categories.Find(id);
            return categories;
        }

        public Categories update(Categories updatedCategories)
        {
            var categories = _context.Categories.Attach(updatedCategories);
            categories.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedCategories;
        }
    }
}
