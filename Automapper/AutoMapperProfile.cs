using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModel;

namespace TaskManagmentSystem.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            
            CreateMap<Tasks, TaskView>().ReverseMap();
            
            CreateMap<Categories, CategoryView>().ReverseMap();

            CreateMap<TasksCategories, TaskCategoriesView>().ReverseMap();

        }
    }
}
