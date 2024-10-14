using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Application.Ingredients.Commands;
using Nutrition.Application.Ingredients.Commands.GetAllIngredients;
using Nutrition.Application.Ingredients.Queries.GetIngredientById;
using System.Net.Sockets;

namespace Nutrition.API.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var ingredients = await mediator.Send(new GetAllIngredientsQuery());

        return Ok(ingredients);
    }

    [HttpGet("{ingredientId}")]
    public async Task<IActionResult> GetByIdAsync(int ingredientId)
    {
        var ingredient = await mediator.Send(new GetIngredientByIdQuery(ingredientId));

        return Ok(ingredient);
    }

    [HttpPatch("{ingredientId}")]
    public async Task<IActionResult> UpdateIngredient([FromRoute] int ingredientId, UpdateIngredientCommand command)
    {
        command.IngredientId = ingredientId;
        await mediator.Send(command);

        return NoContent();
    }
}
