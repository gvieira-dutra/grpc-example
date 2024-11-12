namespace RecipeManager.Api.Exceptions;
public sealed class RecipeNotFoundException(string recipeName) 
    : Exception(recipeName)
{ 
}
