using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutrition.Domain.Entities;
using Nutrition.Domain.Exceptions;
using Nutrition.Domain.Repositories;

namespace Nutrition.Application.Dishes.Commands;

public class UpdateDishCommandHandler(ILogger<UpdateDishCommandHandler> logger,
    IMapper mapper,
    IDishesRepository dishesRepository,
    IDishIngredientsRepository idrepo) : IRequestHandler<UpdateDishIngredientCommand>
{
    public async Task Handle(UpdateDishIngredientCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating dish with id {request.DishId}");

        var dish = await dishesRepository.GetByIdAsync(request.DishId)
            ?? throw new NotFoundException(nameof(Dish), request.DishId.ToString()); ;
        
        mapper.Map(request, dish);

        await dishesRepository.SaveChanges();
        
    }
}
