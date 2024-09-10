
using api.DTOs;
using api.Models;
using AutoMapper;

namespace api.MappedProfiles
{
    public class ProductMappedProfile : Profile
    {

        public ProductMappedProfile()
        {
            CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.CategoryName, prop => prop.MapFrom(src => src.Category.Name));

            CreateMap<ProductCreateDTO, Product>();

            CreateMap<ProductUpdateDTO, Product>();

        }
    }
}