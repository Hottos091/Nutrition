using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Application.Dishes.Commands;
using Nutrition.Application.Dishes.DishDtos;
using Nutrition.Application.Dishes.Queries.GetAllDishes;
using Nutrition.Application.Dishes.Queries.GetDishById;

namespace Nutrition.API.Controllers;


[ApiController]
[Route("api/dishes")]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllAsync()
    {
        var dishes = await mediator.Send(new GetAllDishesQuery());

        return Ok(dishes);
    }

    [HttpGet("{dishId}")]
    public async Task<ActionResult<DishDto?>> GetByIdAsync([FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetDishByIdQuery(dishId));

        return Ok(dish);
    }


    [Authorize]
    [HttpPatch("{dishId}")]
    public async Task<IActionResult> UpdateDish([FromRoute] int dishId, UpdateDishIngredientCommand command)
    {
        command.DishId = dishId;
        await mediator.Send(command);

        return NoContent();
    }


}
