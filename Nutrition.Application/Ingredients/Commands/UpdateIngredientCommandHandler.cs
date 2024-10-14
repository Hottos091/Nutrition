using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nutrition.Domain.Repositories;

namespace Nutrition.Application.Ingredients.Commands;

public class UpdateIngredientCommandHandler(ILogger<UpdateIngredientCommandHandler> logger,
    IMapper mapper,
    IIngredientsRepository ingredientsRepository) : IRequestHandler<UpdateIngredientCommand>
{
    public async Task Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {
        var dish = await ingredientsRepository.GetByIdAsync(request.IngredientId);

        mapper.Map(request, dish);

        await ingredientsRepository.SaveChanges();
    }
}
