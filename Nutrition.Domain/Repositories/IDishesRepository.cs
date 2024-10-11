using Nutrition.Domain.Entities;

namespace Nutrition.Domain.Repositories;

public interface IDishesRepository
{
    Task<IEnumerable<Dish>> GetAllAsync();
    Task<Dish>? GetByIdAsync(int id);
    Task SaveChanges();
}
