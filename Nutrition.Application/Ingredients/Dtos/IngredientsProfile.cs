using AutoMapper;
using Nutrition.Application.Ingredients.Commands;
using Nutrition.Domain.Entities;

namespace Nutrition.Application.Ingredients.Dtos;

public class IngredientsProfile : Profile
{
    public IngredientsProfile()
    {
        CreateMap<UpdateIngredientCommand, Ingredient>()
            .ForMember(i => i.NutritionalInformation, opt => opt.MapFrom(
                src => new NutritionalInformation
                {
                    GramOfProteins = src.GramOfProteins,
                    GramOfCarbohydrates = src.GramOfCarbohydrates,
                    GramOfLipids = src.GramOfLipids,
                    Kalories = src.Kalories
                }));

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
