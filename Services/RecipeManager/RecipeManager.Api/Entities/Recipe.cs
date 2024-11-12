namespace RecipeManager.Api.Entities;

public sealed class Recipe
{
    public string RecipeName { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = new();
    public string AllergenInfo { get; set; } = string.Empty;
}
