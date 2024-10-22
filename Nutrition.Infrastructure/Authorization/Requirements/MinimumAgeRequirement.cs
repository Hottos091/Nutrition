using Microsoft.AspNetCore.Authorization;

namespace Nutrition.Infrastructure.Authorization.Requirements;

public class MinimumAgeRequirement(int minimumAge) : IAuthorizationRequirement
{
    public int MinimumAge { get; } = minimumAge;
}
