namespace RecipeManager.Api.Features.RecipeManager.GetRecipe;

public sealed record GetRecipeResponse(string RecipeName, List<GetRecipeIngredientItem> Ingredients, string AllergenInfo);

public sealed record GetRecipeIngredientItem(string IngredientName, int Quantity);


public sealed class GetRecipeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/recipe-manager/{recipeName}", async (string recipeName, ISender sender) =>
        {
            var query = new GetRecipeQuery(recipeName);

            var result = await sender.Send(query);

            var response = result.Adapt<GetRecipeResponse>();

            return Results.Ok(response);
        })
        .WithName("GetRecipe")
        .Produces<GetRecipeResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Recipe")
        .WithDescription("Get Recipe");
    }
}
