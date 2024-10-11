﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutrition.Application.Dishes.DishDtos;
using Nutrition.Domain.Repositories;

namespace Nutrition.Application.Dishes.Queries.GetDishById;

public class GetDishByIdQueryHandler(ILogger<GetDishByIdQueryHandler> logger,
    IMapper mapper,
    IDishesRepository dishesRepository) : IRequestHandler<GetDishByIdQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting dish with id {DishId}", request.DishId);

        var dish = await dishesRepository.GetByIdAsync(request.DishId);
        var dishDto = mapper.Map<DishDto>(dish);

        return dishDto;
    }
}
