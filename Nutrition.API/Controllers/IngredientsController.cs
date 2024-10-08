using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Application.Ingredients.Commands.GetAllIngredients;

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
}
