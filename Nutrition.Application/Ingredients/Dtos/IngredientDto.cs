namespace Nutrition.Application.Ingredients.Dtos;

public class IngredientDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int? GramOfCarbohydrates { get; set; }
    public int? GramOfLipids { get; set; }
    public int? GramOfProteins { get; set; }
    public int? Kalories { get; set; }
}
