
namespace RecipeManager.Api.Features.RecipeManager.DeleteRecipe;

public sealed record DeleteRecipeCommand(string RecipeName) : IRequest<DeleteRecipeResult>;

public sealed record DeleteRecipeResult(bool IsSuccess);

public sealed class DeleteRecipeCommandValidator 
    : AbstractValidator<DeleteRecipeCommand>
{
	public DeleteRecipeCommandValidator()
	{
		RuleFor(x => x.RecipeName)
			.NotNull()
			.NotEmpty()
			.WithMessage("Recipe name is required!");
	}
}

public sealed class DeleteRecipeCommandHandler(IRecipeManagerRepository repo) : IRequestHandler<DeleteRecipeCommand, DeleteRecipeResult>
{
    public async Task<DeleteRecipeResult> Handle(DeleteRecipeCommand command, CancellationToken cancellationToken)
    {
		await repo.DeleteAsync(command.RecipeName, cancellationToken);

		return new DeleteRecipeResult(true);
    }
}
