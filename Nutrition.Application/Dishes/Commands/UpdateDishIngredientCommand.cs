﻿using MediatR;
using Nutrition.Application.Dishes.DishDtos;
using Nutrition.Application.Dishes.Dtos;
using Nutrition.Domain.Entities;

namespace Nutrition.Application.Dishes.Commands;

public class UpdateDishIngredientCommand : IRequest
{
    public int DishId { get; set; }
    public string? Name { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public List<UpdateDishIngredientOfDishDto> updatedDishIngredients { get; set; }
}
