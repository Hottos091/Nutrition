using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutrition.Application.Ingredients.Dtos;
using Nutrition.Domain.Entities;
using Nutrition.Domain.Exceptions;
using Nutrition.Domain.Repositories;

namespace Nutrition.Application.Ingredients.Queries.GetIngredientById;

public class GetIngredientByIdQueryHandler(ILogger<GetIngredientByIdQueryHandler> logger,
    IMapper mapper,
    IIngredientsRepository ingredientsRepository) : IRequestHandler<GetIngredientByIdQuery, IngredientDto>
{
    public async Task<IngredientDto> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting ingredient with id {Id}", request.IngredientId);

        var ingredient = await ingredientsRepository.GetByIdAsync(request.IngredientId)
            ?? throw new NotFoundException(nameof(Ingredient), request.IngredientId.ToString());

        var ingredientDto = mapper.Map<IngredientDto>(ingredient);

        return ingredientDto;
    }
}
