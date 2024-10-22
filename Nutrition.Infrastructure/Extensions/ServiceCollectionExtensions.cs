using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nutrition.Domain.Entities;
using Nutrition.Domain.Repositories;
using Nutrition.Infrastructure.Authorization;
using Nutrition.Infrastructure.Authorization.Requirements;
using Nutrition.Infrastructure.Persistence;
using Nutrition.Infrastructure.Repositories;
using Nutrition.Infrastructure.Seeders;

namespace Nutrition.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("NutritionDB");

        services.AddDbContext<NutritionDBContext>(options => options
            .UseSqlServer(connectionString)
            .EnableSensitiveDataLogging() //TODO : Change when in PROD
        );
        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<NutritionUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<NutritionDBContext>();

        services.AddScoped<INutritionSeeder, NutritionSeeder>();
        services.AddScoped<IIngredientsRepository, IngredientsRepository>();
        services.AddScoped<IDishesRepository, DishesRepository>();
        services.AddScoped<IDishIngredientsRepository, DishIngredientsRepository>();

        services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.IsAtLeast18,
                builder => builder.AddRequirements(new MinimumAgeRequirement(18)));

        services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();


    }
}
