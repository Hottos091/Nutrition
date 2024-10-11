using AutoMapper;
using Nutrition.Application.Dishes.Dtos;
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

        CreateMap<UpdateDishIngredientOfDishDto, DishIngredient>()
            .ForMember(di => di.QuantityIngredient, opt => opt.MapFrom(src => src.QuantityIngredient))
            .ForMember(di => di.IngredientId, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(di => di.TypeOfIngredient, opt => opt.MapFrom(src => src.TypeOfIngredient));
    }
}
