using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutrition.Application.DishIngredients.Dtos;
using Nutrition.Domain.Repositories;

namespace Nutrition.Application.Dishes.Queries.GetAllDishes;

public class GetAllDishIngredientsQueryHandler(ILogger<GetAllDishIngredientsQueryHandler> logger,
    IMapper mapper,
    IDishIngredientsRepository dishIngredientsRepository) : IRequestHandler<GetAllDishIngredientsQuery, IEnumerable<DishIngredientDto>>
{
    public async Task<IEnumerable<DishIngredientDto>> Handle(GetAllDishIngredientsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all dish ingredients");

        var dishIngredients = await dishIngredientsRepository.GetAllAsync();
        var dishIngredientDtos = mapper.Map<IEnumerable<DishIngredientDto>>(dishIngredients);

        return dishIngredientDtos;
    }
}
