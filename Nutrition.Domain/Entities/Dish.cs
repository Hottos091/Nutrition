using System.Text.Json.Serialization;

namespace Nutrition.Domain.Entities;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public List<DishIngredient> DishIngredients { get; set; }
}
