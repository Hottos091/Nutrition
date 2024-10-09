using AutoMapper;
using Nutrition.Domain.Entities;

namespace Nutrition.Application.Dishes.DishDtos;

public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDto>()
            .ForMember(d => d.DishIngredients, opt => opt.MapFrom(src => src.DishIngredients));
    }
}
