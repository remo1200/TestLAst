
using api.DTOs;
using api.Models;
using AutoMapper;

namespace api.MappedProfiles
{
    public class CategoryMappedProfile : Profile
    {

        public CategoryMappedProfile()
        {
            CreateMap<Category, CategoryDTO>();

            CreateMap<CategoryCreateDTO, Category>();

            CreateMap<CategoryUpdateDTO, Category>();

        }
    }
}