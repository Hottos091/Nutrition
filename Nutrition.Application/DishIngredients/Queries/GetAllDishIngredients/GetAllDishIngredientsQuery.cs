using MediatR;
using Nutrition.Application.DishIngredients.Dtos;

namespace Nutrition.Application.Dishes.Queries.GetAllDishes;

public class GetAllDishIngredientsQuery : IRequest<IEnumerable<DishIngredientDto>>
{
}
