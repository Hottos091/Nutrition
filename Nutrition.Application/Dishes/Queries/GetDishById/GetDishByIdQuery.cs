using MediatR;
using Nutrition.Application.Dishes.DishDtos;

namespace Nutrition.Application.Dishes.Queries.GetDishById;

public class GetDishByIdQuery(int id) : IRequest<DishDto>
{
    public int DishId { get; } = id;
}
