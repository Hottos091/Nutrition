using Microsoft.EntityFrameworkCore;
using Nutrition.Domain.Entities;


namespace Nutrition.Infrastructure.Persistence;

public class NutritionDBContext(DbContextOptions<NutritionDBContext> options) : DbContext(options)
{
    internal DbSet<User> Users { get; set; }
    internal DbSet<Dish> Dishes { get; set; }
    internal DbSet<Ingredient> Ingredients { get; set; }
    internal DbSet<Consumption> Consumptions { get; set; }
    internal DbSet<DishIngredient> DishIngredients { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ingredient>()
            .OwnsOne(i => i.NutritionalInformation);

        //Relation N-N entre Dish et Ingredient via DishIngredient
        modelBuilder.Entity<DishIngredient>()
            .HasKey(di => new { di.DishId, di.IngredientId }); //Composite Key

        modelBuilder.Entity<DishIngredient>()
            .HasOne(di => di.Dish)
            .WithMany(d => d.DishIngredients)
            .HasForeignKey(di => di.DishId);

        modelBuilder.Entity<DishIngredient>()
            .HasOne(di => di.Ingredient)
            .WithMany()
            .HasForeignKey(di => di.IngredientId);

        //Relation 1-N entre Consumption et Dish
        modelBuilder.Entity<Consumption>()
            .HasOne(c => c.Dish)
            .WithMany()
            .HasForeignKey(c => c.DishId);

        //Relation 1-N entre Consumption et User
        modelBuilder.Entity<Consumption>()
            .HasOne(c => c.User)
            .WithMany(u => u.Consumptions)
            .HasForeignKey(c => c.UserId);
    }
}
