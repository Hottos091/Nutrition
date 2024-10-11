namespace Nutrition.Application.Dishes.Dtos;

public class UpdateDishIngredientOfDishDto
{
    public int IngredientId { get; set; }
    public int QuantityIngredient { get; set; }
    public string TypeOfIngredient { get; set; } = default!;
}
