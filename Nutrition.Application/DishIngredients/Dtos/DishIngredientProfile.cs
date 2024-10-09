using AutoMapper;
using Nutrition.Domain.Entities;

namespace Nutrition.Application.DishIngredients.Dtos;

public class DishIngredientProfile : Profile
{
    public DishIngredientProfile()
    {
        CreateMap<DishIngredient, DishIngredientDto>()
            .ForMember(di => di.DishName, opt => opt.MapFrom(src => src.Dish.Name))
            .ForMember(di => di.DishDescription, opt => opt.MapFrom(src => src.Dish.Description))
            .ForMember(di => di.Ingredient, opt => opt.MapFrom(src => src.Ingredient));
    }
}
