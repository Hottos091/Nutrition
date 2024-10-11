using AutoMapper;
using Nutrition.Application.Dishes.Commands;
using Nutrition.Domain.Entities;

namespace Nutrition.Application.Dishes.DishDtos;

public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDto>()
            .ForMember(d => d.DishIngredients, opt => opt.MapFrom(src => src.DishIngredients));


        CreateMap<UpdateDishIngredientCommand, Dish>()
            .ForMember(d => d.DishIngredients, opt => opt.MapFrom(src => src.updatedDishIngredients));
    }
}
