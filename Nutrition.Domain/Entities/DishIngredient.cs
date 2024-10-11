using System.Text.Json.Serialization;

namespace Nutrition.Domain.Entities;

public class DishIngredient
{
    public int QuantityIngredient { get; set; }
    public string TypeOfIngredient { get; set; }

    public int DishId { get; set; }

    [JsonIgnore]
    public Dish Dish { get; set; }
    
    public int IngredientId {  get; set; }
    public Ingredient Ingredient { get; set; }
}
 