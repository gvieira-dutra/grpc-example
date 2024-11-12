﻿// <auto-generated />
using AllergenCheck.Grpc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AllergenCheck.Grpc.Migrations
{
    [DbContext(typeof(AllergenCheckContext))]
    [Migration("20241111193807_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("AllergenCheck.Grpc.Entities.Allergen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descrip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SeverityLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Allergens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descrip = "A highly allergenic seafood, can cause severe reactions like anaphylaxis.",
                            IngredientName = "SHRIMP",
                            SeverityLevel = 5
                        },
                        new
                        {
                            Id = 2,
                            Descrip = "Common allergen, can cause digestive issues or skin reactions.",
                            IngredientName = "MILK",
                            SeverityLevel = 3
                        },
                        new
                        {
                            Id = 3,
                            Descrip = "One of the most dangerous allergens, can trigger life-threatening anaphylaxis.",
                            IngredientName = "PEANUT",
                            SeverityLevel = 5
                        },
                        new
                        {
                            Id = 4,
                            Descrip = "Common allergen, can cause skin reactions and gastrointestinal distress.",
                            IngredientName = "EGG",
                            SeverityLevel = 3
                        },
                        new
                        {
                            Id = 5,
                            Descrip = "Can cause mild digestive discomfort or skin irritation for some people.",
                            IngredientName = "WHEAT",
                            SeverityLevel = 2
                        },
                        new
                        {
                            Id = 6,
                            Descrip = "Common in processed foods, can lead to mild or moderate allergic reactions.",
                            IngredientName = "SOY",
                            SeverityLevel = 3
                        },
                        new
                        {
                            Id = 7,
                            Descrip = "Includes almonds, walnuts, and others; severe reactions, including anaphylaxis, are possible.",
                            IngredientName = "NUT",
                            SeverityLevel = 4
                        },
                        new
                        {
                            Id = 8,
                            Descrip = "Typically causes discomfort in individuals with gluten sensitivity or celiac disease.",
                            IngredientName = "GLUTEN",
                            SeverityLevel = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
