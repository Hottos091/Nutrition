﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Nutrition.Application.Users;


public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}


public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidOperationException("User context is null, thus doesn't exist");
        }

        if(user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);
        var dateOfBirthString = user.FindFirst(c => c.Type == "DateOfBirth")?.Value;
        var dateOfBirth = dateOfBirthString == null
            ? (DateOnly?)null
            : DateOnly.ParseExact(dateOfBirthString, "yyyy-MM-dd");

        return new CurrentUser(userId, email, roles, dateOfBirth);
    }
}