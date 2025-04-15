namespace RecipeManager.Api.Features.RecipeManager.CreateRecipe;

public sealed record CreateRecipeCommand(string RecipeName, List<Ingredient> Ingredients)
    : IRequest<CreateRecipeResult>;

public sealed record CreateRecipeResult(string RecipeName);

public sealed class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
{
    public CreateRecipeCommandValidator()
    {
        RuleFor(x => x.RecipeName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter a name for your recipe.");
    }
}

public sealed class CreateRecipeHandler(
    IRecipeManagerRepository repo,
    AllergenCheckProtoService.AllergenCheckProtoServiceClient allergenService
) : IRequestHandler<CreateRecipeCommand, CreateRecipeResult>
{
    public async Task<CreateRecipeResult> Handle(
        CreateRecipeCommand command,
        CancellationToken cancellationToken
    )
    {
        var recipe = command.Adapt<Recipe>();

        await GetAllergenInfo(recipe, cancellationToken);

        await repo.CreateAsync(recipe, cancellationToken);

        return new CreateRecipeResult(recipe.RecipeName);
    }

    private async Task GetAllergenInfo(Recipe recipe, CancellationToken cancellationToken)
    {
        recipe.AllergenInfo = "Potential Allergen Info:";

        foreach (var item in recipe.Ingredients)
        {
            var isAllergen = await allergenService.GetAllergenAsync(
                new GetAllergenRequest { IngredientName = item.IngredientName.ToUpper() },
                cancellationToken: cancellationToken
            );

            if (isAllergen.IngredientName != "Not Found")
            {
                recipe.AllergenInfo +=
                    " "
                    + isAllergen.IngredientName
                    + " is an allergen with Severity Level: "
                    + isAllergen.SeverityLevel;
            }
        }
    }
}

/*
 {
  "recipeName": "t1",
  "ingredients": [
    {
      "ingredientName": "turkey",
      "quantity": 1
    },
    {
      "ingredientName": "onion",
      "quantity": 1
    }
  ]
}
 */
