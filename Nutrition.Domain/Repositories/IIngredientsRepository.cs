using Nutrition.Domain.Entities;

namespace Nutrition.Domain.Repositories;

public interface IIngredientsRepository
{
    Task<IEnumerable<Ingredient>> GetAllAsync();
}
