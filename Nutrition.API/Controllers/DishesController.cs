﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutrition.Application.Dishes.Queries.GetAllDishes;

namespace Nutrition.API.Controllers;


[ApiController]
[Route("api/dishes")]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var dishes = await mediator.Send(new GetAllDishesQuery());

        return Ok(dishes);
    }
}
