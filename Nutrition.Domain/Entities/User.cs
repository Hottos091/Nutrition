using Microsoft.AspNetCore.Identity;

namespace Nutrition.Domain.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }
    public float? Weight { get; set; }
    public int? HeightCm { get; set; }
    public List<Consumption>? Consumptions { get; set; } = [];
}
