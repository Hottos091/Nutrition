using Microsoft.EntityFrameworkCore;
using Nutrition.Domain.Entities;
using Nutrition.Domain.Repositories;
using Nutrition.Infrastructure.Persistence;

namespace Nutrition.Infrastructure.Repositories;

internal class DishIngredientsRepository(NutritionDBContext dbContext) 
    : IDishIngredientsRepository
{
    public async Task<IEnumerable<DishIngredient>> GetAllAsync()
    {
        var dishIngredients = await dbContext.DishIngredients
            .Include(di => di.Dish)
            .Include(di => di.Ingredient)
            .ToListAsync();

        return dishIngredients;
    }
}
