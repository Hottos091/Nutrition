namespace Nutrition.Domain.Entities;

public class Consumption
{
    public int Id { get; set; }
    public DateTime ConsumptionDate { get; set; }
    public int ConsumedPortions { get; set; }


    public string UserId { get; set; }
    public User User { get; set; }

    public int DishId { get; set; }
    public Dish Dish { get; set; }

}
