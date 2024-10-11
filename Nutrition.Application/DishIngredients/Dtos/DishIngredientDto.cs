using Nutrition.Application.Dishes.DishDtos;
using Nutrition.Application.Ingredients.Dtos;
using Nutrition.Domain.Entities;

namespace Nutrition.Application.DishIngredients.Dtos;

public class DishIngredientDto
{
    public int QuantityIngredient { get; set; }
    public string TypeOfIngredient { get; set; } = default!;

    public string DishName { get; set; }
    public string DishDescription { get; set; }

    public IngredientDto Ingredient { get; set; }
}