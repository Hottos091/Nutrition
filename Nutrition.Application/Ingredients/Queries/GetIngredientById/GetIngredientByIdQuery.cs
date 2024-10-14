using MediatR;
using Nutrition.Application.Ingredients.Dtos;

namespace Nutrition.Application.Ingredients.Queries.GetIngredientById;

public class GetIngredientByIdQuery(int id) : IRequest<IngredientDto>
{
    public int IngredientId { get; set; } = id;
}
