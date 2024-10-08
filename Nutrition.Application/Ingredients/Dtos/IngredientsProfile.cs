using AutoMapper;
using Nutrition.Domain.Entities;

namespace Nutrition.Application.Ingredients.Dtos;

public class IngredientsProfile : Profile
{
    public IngredientsProfile()
    {
        CreateMap<Ingredient, IngredientDto>()
            .ForMember(dto => dto.GramOfProteins, opt =>
            opt.MapFrom(src => src.NutritionalInformation.GramOfProteins))
            .ForMember(dto => dto.GramOfCarbohydrates, opt =>
            opt.MapFrom(src => src.NutritionalInformation.GramOfCarbohydrates))
            .ForMember(dto => dto.GramOfLipids, opt =>
            opt.MapFrom(src => src.NutritionalInformation.GramOfLipids))
            .ForMember(dto => dto.Kalories, opt =>
            opt.MapFrom(src => src.NutritionalInformation.Kalories));
    }
}
