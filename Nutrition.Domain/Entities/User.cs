namespace Nutrition.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public List<Consumption> Consumptions { get; set; }
}
