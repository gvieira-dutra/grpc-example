namespace RecipeManager.Api.Services;

public sealed class RecipeManagerRepository(IDocumentSession session) : IRecipeManagerRepository
{
    public async Task<Recipe> CreateAsync(
        Recipe recipe,
        CancellationToken cancellationToken = default
    )
    {
        session.Store(recipe);
        await session.SaveChangesAsync(cancellationToken);

        return recipe;
    }

    public async Task<bool> DeleteAsync(
        string recipeName,
        CancellationToken cancellationToken = default
    )
    {
        session.Delete<Recipe>(recipeName);
        await session.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<Recipe> GetAsync(
        string recipeNmae,
        CancellationToken cancellationToken = default
    )
    {
        var recipe = await session.LoadAsync<Recipe>(recipeNmae, cancellationToken);

        return recipe is null
            ? throw new RecipeNotFoundException("Could not find recipe: " + recipeNmae)
            : recipe;
    }
}
