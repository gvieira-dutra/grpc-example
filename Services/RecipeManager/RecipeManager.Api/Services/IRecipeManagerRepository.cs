namespace RecipeManager.Api.Services;

public interface IRecipeManagerRepository
{
    Task<Recipe> CreateAsync(Recipe recipe, CancellationToken cancellationToken = default);
    Task<Recipe> GetAsync(string recipeName, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string recipeName, CancellationToken cancellationToken = default);
}
