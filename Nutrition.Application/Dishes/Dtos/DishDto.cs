using Nutrition.Application.DishIngredients.Dtos;

namespace Nutrition.Application.Dishes.DishDtos;

public class DishDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public List<DishIngredientDto> DishIngredients { get; set; }
}
