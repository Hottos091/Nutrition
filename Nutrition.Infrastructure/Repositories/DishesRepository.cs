using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Nutrition.Domain.Entities;
using Nutrition.Domain.Repositories;
using Nutrition.Infrastructure.Persistence;

namespace Nutrition.Infrastructure.Repositories;

internal class DishRepository(NutritionDBContext dbContext)
    : IDishesRepository
{
    public async Task<IEnumerable<Dish>> GetAllAsync()
    {
        var dishes = await dbContext.Dishes.ToListAsync();
        return dishes;
    }
}
