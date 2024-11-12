using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AllergenCheck.Grpc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientName = table.Column<string>(type: "TEXT", nullable: false),
                    SeverityLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    Descrip = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Descrip", "IngredientName", "SeverityLevel" },
                values: new object[,]
                {
                    { 1, "A highly allergenic seafood, can cause severe reactions like anaphylaxis.", "SHRIMP", 5 },
                    { 2, "Common allergen, can cause digestive issues or skin reactions.", "MILK", 3 },
                    { 3, "One of the most dangerous allergens, can trigger life-threatening anaphylaxis.", "PEANUT", 5 },
                    { 4, "Common allergen, can cause skin reactions and gastrointestinal distress.", "EGG", 3 },
                    { 5, "Can cause mild digestive discomfort or skin irritation for some people.", "WHEAT", 2 },
                    { 6, "Common in processed foods, can lead to mild or moderate allergic reactions.", "SOY", 3 },
                    { 7, "Includes almonds, walnuts, and others; severe reactions, including anaphylaxis, are possible.", "NUT", 4 },
                    { 8, "Typically causes discomfort in individuals with gluten sensitivity or celiac disease.", "GLUTEN", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergens");
        }
    }
}
