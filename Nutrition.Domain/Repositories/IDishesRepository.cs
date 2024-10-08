using Nutrition.Domain.Entities;

namespace Nutrition.Domain.Repositories;

public interface IDishesRepository
{
    Task<IEnumerable<Dish>> GetAllAsync();
}
