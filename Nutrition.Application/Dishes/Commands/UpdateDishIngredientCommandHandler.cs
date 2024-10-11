using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutrition.Domain.Repositories;

namespace Nutrition.Application.Dishes.Commands;

public class UpdateDishCommandHandler(ILogger<UpdateDishCommandHandler> logger,
    IMapper mapper,
    IDishesRepository dishesRepository,
    IDishIngredientsRepository idrepo) : IRequestHandler<UpdateDishIngredientCommand>
{
    public async Task Handle(UpdateDishIngredientCommand request, CancellationToken cancellationToken)
    {
        var dish = await dishesRepository.GetByIdAsync(request.DishId);

        mapper.Map(request, dish);

        await dishesRepository.SaveChanges();
        
    }
}
