using MediatR;
using Nutrition.Application.Dishes.DishDtos;
using Nutrition.Application.DishIngredients.Dtos;

namespace Nutrition.Application.Dishes.Queries.GetAllDishes;

public class GetAllDishesQuery : IRequest<IEnumerable<DishDto>>
{
}
