using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutrition.Application.Ingredients.Dtos;
using Nutrition.Domain.Repositories;

namespace Nutrition.Application.Ingredients.Commands.GetAllIngredients;

public class GetAllIngredientsQueryHandler(ILogger<GetAllIngredientsQueryHandler> logger,
    IMapper mapper,
    IIngredientsRepository ingredientsRepository) : IRequestHandler<GetAllIngredientsQuery, IEnumerable<IngredientDto>>
{
    public async Task<IEnumerable<IngredientDto>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all ingredients");

        var ingredients = await ingredientsRepository.GetAllAsync();
        var ingredientsDto = mapper.Map<IEnumerable<IngredientDto>>(ingredients);

        return ingredientsDto;
    }
}
