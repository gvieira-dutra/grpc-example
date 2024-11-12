namespace RecipeManager.Api.Features.RecipeManager.GetRecipe;

public sealed record GetRecipeQuery(string RecipeName) 
    : IRequest<GetRecipeResult>;

public sealed record GetRecipeResult(string RecipeName, List<Ingredient> Ingredients, string AllergenInfo);

public class GetRecipeHandler(IRecipeManagerRepository repo) :
    IRequestHandler<GetRecipeQuery, GetRecipeResult>
{
    public async Task<GetRecipeResult> Handle(GetRecipeQuery query, CancellationToken cancellationToken)
    {
        var recipe = await repo.GetAsync(query.RecipeName, cancellationToken);

        var result = recipe.Adapt<GetRecipeResult>();

        return result;
    }
}
