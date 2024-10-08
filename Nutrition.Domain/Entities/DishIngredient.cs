namespace Nutrition.Domain.Entities;

public class DishIngredient
{
    public int Id { get; set; }
    public int QuantityIngredient { get; set; }
    public string TypeOfIngredient { get; set; }

    public int DishId { get; set; }
    public Dish Dish { get; set; }
    
    public int IngredientId {  get; set; }
    public Ingredient Ingredient { get; set; }
}
 