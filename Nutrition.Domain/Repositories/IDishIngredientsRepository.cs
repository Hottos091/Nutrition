using Nutrition.Domain.Entities;

namespace Nutrition.Domain.Repositories;

public interface IDishIngredientsRepository
{
    Task<IEnumerable<DishIngredient>> GetAllAsync();
}
