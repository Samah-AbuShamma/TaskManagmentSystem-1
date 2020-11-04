using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    public interface ICategoriesRepository
    {
        public Categories createCategories(Categories newCategories);
        public Categories delete(int id);
        public Categories getCategoryById(int id);
        public Categories update(Categories updatedTask);
        public IEnumerable<Categories> getAllCategories();
    }
}
