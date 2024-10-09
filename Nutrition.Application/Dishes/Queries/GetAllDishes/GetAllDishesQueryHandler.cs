using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutrition.Application.Dishes.DishDtos;
using Nutrition.Domain.Repositories;

namespace Nutrition.Application.Dishes.Queries.GetAllDishes;

public class GetAllDishesQueryHandler(ILogger<GetAllDishesQueryHandler> logger, 
    IMapper mapper,
    IDishesRepository dishesRepository) : IRequestHandler<GetAllDishesQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all dishes");

        var dishes = await dishesRepository.GetAllAsync();
        var dishDtos = mapper.Map<IEnumerable<DishDto>>(dishes);

        return dishDtos;
    }
}
