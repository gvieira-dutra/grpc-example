namespace RecipeManager.Api.Features.RecipeManager.DeleteRecipe;

public sealed record DeleteRecipeResponse(bool IsSuccess);

public sealed class DeleteRecipeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/recipe-manager/{recipeName}", async (string recipeName, ISender sender) =>
        {
            var command = new DeleteRecipeCommand(recipeName);

            var result = await sender.Send(command);

            var response = result.Adapt<DeleteRecipeResponse>();

            return Results.Ok(response);
        })
            .WithName("DeleteRecipe")
            .Produces<DeleteRecipeResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithDescription("Delete Recipe");
    }
}
