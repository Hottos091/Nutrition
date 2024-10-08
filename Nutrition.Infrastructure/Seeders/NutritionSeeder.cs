﻿using Microsoft.EntityFrameworkCore;
using Nutrition.Domain.Entities;
using Nutrition.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Infrastructure.Seeders
{
    internal class NutritionSeeder(NutritionDBContext dbContext) : INutritionSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Dishes.Any())
                {
                    var restaurants = GetDishes();
                    dbContext.Dishes.AddRange(restaurants);
                    await dbContext.SaveChangesAsync();
                }
            }
        }


        private IEnumerable<Dish> GetDishes()
        {
            Ingredient chicken = new()
            {
                Name = "Chicken Breast",
                NutritionalInformation = new NutritionalInformation()
                {
                    GramOfCarbohydrates = 0,
                    GramOfLipids = 4, // Valeurs arrondies
                    GramOfProteins = 31,
                    Kalories = 165
                }
            };

            Ingredient lettuce = new()
            {
                Name = "Lettuce",
                NutritionalInformation = new NutritionalInformation()
                {
                    GramOfCarbohydrates = 3,
                    GramOfLipids = 0,
                    GramOfProteins = 1,
                    Kalories = 15
                }
            };

            Ingredient tomato = new()
            {
                Name = "Tomato",
                NutritionalInformation = new NutritionalInformation()
                {
                    GramOfCarbohydrates = 4,
                    GramOfLipids = 0,
                    GramOfProteins = 1,
                    Kalories = 18
                }
            };

            List<Dish> dishes = new()
            {
                new Dish()
                {
                    Name = "Chicken Salad",
                    Description = "A healthy chicken salad.",
                    Ingredients = new List<DishIngredient>()
                    {
                        new DishIngredient { Ingredient = chicken, QuantityIngredient = 200, TypeOfIngredient = "Grams" }, // Quantité en grammes
                        new DishIngredient { Ingredient = lettuce, QuantityIngredient = 1, TypeOfIngredient = "Pièces"  },
                        new DishIngredient { Ingredient = tomato, QuantityIngredient = 2, TypeOfIngredient = "Pièces"  }
                    }
                },
                new Dish()
                {
                    Name = "Grilled Chicken",
                    Description = "Grilled chicken with spices.",
                    Ingredients = new List<DishIngredient>()
                    {
                        new DishIngredient { Ingredient = chicken, QuantityIngredient = 250, TypeOfIngredient = "Grams"  }
                    }
                }
            };

            return dishes;
        }
    }
}