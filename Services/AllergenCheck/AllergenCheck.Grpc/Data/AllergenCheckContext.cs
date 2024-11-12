namespace AllergenCheck.Grpc.Data;

public class AllergenCheckContext(DbContextOptions<AllergenCheckContext> options) 
    : DbContext(options)
{
    public DbSet<Allergen> Allergens { get; set; } = default;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergen>(a =>
        {
            a.HasData(
                new Allergen
                {
                    Id = 1,
                    IngredientName = "SHRIMP",
                    SeverityLevel = 5,
                    Descrip = "A highly allergenic seafood, can cause severe reactions like anaphylaxis."
                },
                new Allergen
                {
                    Id = 2,
                    IngredientName = "MILK",
                    SeverityLevel = 3,
                    Descrip = "Common allergen, can cause digestive issues or skin reactions."
                },
                new Allergen
                {
                    Id = 3,
                    IngredientName = "PEANUT",
                    SeverityLevel = 5,
                    Descrip = "One of the most dangerous allergens, can trigger life-threatening anaphylaxis."
                },
                new Allergen
                {
                    Id = 4,
                    IngredientName = "EGG",
                    SeverityLevel = 3,
                    Descrip = "Common allergen, can cause skin reactions and gastrointestinal distress."
                },
                new Allergen
                {
                    Id = 5,
                    IngredientName = "WHEAT",
                    SeverityLevel = 2,
                    Descrip = "Can cause mild digestive discomfort or skin irritation for some people."
                },
                new Allergen
                {
                    Id = 6,
                    IngredientName = "SOY",
                    SeverityLevel = 3,
                    Descrip = "Common in processed foods, can lead to mild or moderate allergic reactions."
                },
                new Allergen
                {
                    Id = 7,
                    IngredientName = "NUT",
                    SeverityLevel = 4,
                    Descrip = "Includes almonds, walnuts, and others; severe reactions, including anaphylaxis, are possible."
                },
                new Allergen
                {
                    Id = 8,
                    IngredientName = "GLUTEN",
                    SeverityLevel = 2,
                    Descrip = "Typically causes discomfort in individuals with gluten sensitivity or celiac disease."
                }
            );

        });
    }
}
