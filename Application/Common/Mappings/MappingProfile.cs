using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.CategoryName));

            CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.Element, opt => opt.MapFrom(src => src.Element))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));
        }
    }
}
