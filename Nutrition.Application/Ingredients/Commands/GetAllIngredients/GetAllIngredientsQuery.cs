using MediatR;
using Nutrition.Application.Ingredients.Dtos;

namespace Nutrition.Application.Ingredients.Commands.GetAllIngredients;

public class GetAllIngredientsQuery : IRequest<IEnumerable<IngredientDto>>
{
}
