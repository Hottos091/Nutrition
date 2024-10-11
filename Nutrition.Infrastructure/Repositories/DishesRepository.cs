using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Nutrition.Domain.Entities;
using Nutrition.Domain.Repositories;
using Nutrition.Infrastructure.Persistence;

namespace Nutrition.Infrastructure.Repositories;

internal class DishesRepository(NutritionDBContext dbContext)
    : IDishesRepository
{
    public async Task<IEnumerable<Dish>> GetAllAsync()
    {
        var dishes = await dbContext.Dishes
            .Include(d => d.DishIngredients)
            .ThenInclude(di => di.Ingredient)
            .ToListAsync();

        return dishes;
    }

    public async Task<Dish>? GetByIdAsync(int id)
    {
        var dish = await dbContext.Dishes
            .Include(dish => dish.DishIngredients)
            .ThenInclude(di => di.Ingredient)
            .FirstOrDefaultAsync(dish => dish.Id == id);
        
        return dish;
    }

    public Task SaveChanges()
     => dbContext.SaveChangesAsync();
}
