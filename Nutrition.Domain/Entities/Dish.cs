﻿namespace Nutrition.Domain.Entities;

public class Dish
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }

    public List<DishIngredient> Ingredients { get; set; }

}