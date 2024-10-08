using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nutrition.Infrastructure.Persistence;

namespace Nutrition.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("NutritionDB");

        services.AddDbContext<NutritionDBContext>(options => options.UseSqlServer(connectionString));

    }
}
