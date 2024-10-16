﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nutrition.Infrastructure.Persistence;

#nullable disable

namespace Nutrition.Infrastructure.Migrations
{
    [DbContext(typeof(NutritionDBContext))]
    partial class NutritionDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nutrition.Domain.Entities.Consumption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsumedPortions")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConsumptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("UserId");

                    b.ToTable("Consumptions");
                });

            modelBuilder.Entity("Nutrition.Domain.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Nutrition.Domain.Entities.DishIngredient", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityIngredient")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfIngredient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DishId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DishIngredients");
                });

            modelBuilder.Entity("Nutrition.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Nutrition.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Nutrition.Domain.Entities.Consumption", b =>
                {
                    b.HasOne("Nutrition.Domain.Entities.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nutrition.Domain.Entities.User", "User")
                        .WithMany("Consumptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Nutrition.Domain.Entities.DishIngredient", b =>
                {
                    b.HasOne("Nutrition.Domain.Entities.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nutrition.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Nutrition.Domain.Entities.Ingredient", b =>
                {
                    b.OwnsOne("Nutrition.Domain.Entities.NutritionalInformation", "NutritionalInformation", b1 =>
                        {
                            b1.Property<int>("IngredientId")
                                .HasColumnType("int");

                            b1.Property<int>("GramOfCarbohydrates")
                                .HasColumnType("int");

                            b1.Property<int>("GramOfLipids")
                                .HasColumnType("int");

                            b1.Property<int>("GramOfProteins")
                                .HasColumnType("int");

                            b1.Property<int>("Kalories")
                                .HasColumnType("int");

                            b1.HasKey("IngredientId");

                            b1.ToTable("Ingredients");

                            b1.WithOwner()
                                .HasForeignKey("IngredientId");
                        });

                    b.Navigation("NutritionalInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("Nutrition.Domain.Entities.Dish", b =>
                {
                    b.Navigation("DishIngredients");
                });

            modelBuilder.Entity("Nutrition.Domain.Entities.User", b =>
                {
                    b.Navigation("Consumptions");
                });
#pragma warning restore 612, 618
        }
    }
}
