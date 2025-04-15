namespace RecipeManager.Api.Features.RecipeManager.CreateRecipe;

public sealed record CreateRecipeRequest(string RecipeName, List<CreateIngredientItem> Ingredients);

public sealed record CreateIngredientItem(string IngredientName, int Quantity);

public sealed record CreateRecipeResponse(string RecipeName);

public sealed class CreateRecipeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/api/recipe-manager/",
                async (CreateRecipeRequest request, ISender sender) =>
                {
                    var command = request.Adapt<CreateRecipeCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<CreateRecipeResponse>();

                    return Results.Created($"/api/recipe-manager/{response.RecipeName}", response);
                }
            )
            .WithName("CreateRecipe")
            .Produces<CreateRecipeResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Recipe")
            .WithDescription("Create Recipe");
    }
}
