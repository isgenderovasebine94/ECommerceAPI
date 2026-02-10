using AutoMapper;
using EcommerceAPI.Entities;
using EcommerceAPI.Entities.Auth;
using EcommerceAPI.Entities.Dtos.Auth;
using EcommerceAPI.Entities.Dtos.Categories;
using EcommerceAPI.Entities.Dtos.Countries;
using EcommerceAPI.Entities.Dtos.Products;

namespace EcommerceAPI.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, GetCategoryDto>().ForMember(c => c.CategoryName, opt => opt.MapFrom(c => c.Name));
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Product, GetProductDto>().ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.Category.Name));

            CreateMap<CreateCountryDto, Country>();
            CreateMap<UpdateCountryDto, Country>().ReverseMap();
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}
