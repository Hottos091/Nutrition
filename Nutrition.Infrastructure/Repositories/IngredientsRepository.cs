using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Nutrition.Domain.Entities;
using Nutrition.Domain.Repositories;
using Nutrition.Infrastructure.Persistence;

namespace Nutrition.Infrastructure.Repositories;

internal class IngredientsRepository(NutritionDBContext dbContext)
    : IIngredientsRepository
{
    public async Task<IEnumerable<Ingredient>> GetAllAsync()
    {
        var ingredients = await dbContext.Ingredients.ToListAsync();
        return ingredients;
    }

    public async Task<Ingredient> GetByIdAsync(int id)
    {
        var ingredient = await dbContext.Ingredients
            .FirstOrDefaultAsync(i => i.Id == id);

        return ingredient;
    }

    public Task SaveChanges()
    => dbContext.SaveChangesAsync();
}
