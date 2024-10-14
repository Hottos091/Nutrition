using MediatR;
using Nutrition.Application.Ingredients.Dtos;

namespace Nutrition.Application.Ingredients.Commands;

public class UpdateIngredientCommand : IRequest
{
    public int IngredientId { get; set; }  
    public string? Name { get; set; } = default!;
    public int? GramOfCarbohydrates { get; set; }
    public int? GramOfLipids { get; set; }
    public int? GramOfProteins { get; set; }
    public int? Kalories { get; set; }
}

