using AllergenService.Grpc;
using Google.Protobuf;

namespace AllergenCheck.Grpc.Services;

public class AllergenCheckService(AllergenCheckContext dbContext, ILogger<AllergenCheckService> logger)
    : AllergenCheckProtoService.AllergenCheckProtoServiceBase

{
    public override async Task<AllergenModel> GetAllergen(
        GetAllergenRequest request,
        ServerCallContext context)
    {
        var allergenInfo = await dbContext
            .Allergens
            .FirstOrDefaultAsync(a => a.IngredientName == request.IngredientName);

        if (allergenInfo is null)
        {
            logger.LogInformation(
                "Ingredient not found on database: {ingredientName}", request.IngredientName);

            return new AllergenModel
            {
                IngredientName = "Not Found",
                SeverityLevel = 0,
                Descrip = "Not Found"
            };
        }

        logger.LogInformation(
            "Found allergen ingredient: {IngredientName}", allergenInfo.IngredientName);

        return allergenInfo.ToModel();
    }

    public override async Task<AllergenModel> CreateAllergen(
    CreateAllergenRequest request,
    ServerCallContext context)
    {
        var allergen = request.Allergen.ToEntity();

        dbContext.Add(allergen);
        await dbContext.SaveChangesAsync();

        logger.LogInformation(
            "Success! New allergen info added to database."
            );

        return allergen.ToModel();

    }

    public override async Task<AllergenModel> UpdateAllergen(
UpdateAllergenRequest request,
ServerCallContext context)
    {
        var allergen = await dbContext.Allergens
            .FirstOrDefaultAsync(a => a.IngredientName == request.Allergen.IngredientName);

        if(allergen is null)
        {
            logger.LogInformation(
                "Product not found on database: {productName}!", request.Allergen.IngredientName
                );

            throw new RpcException(
                new Status(
                StatusCode.NotFound,
                $"Could not find ingredient: {request.Allergen.IngredientName}")
                );         
        }

            allergen.Descrip = request.Allergen.Descrip;
            allergen.IngredientName = request.Allergen.IngredientName;
            allergen.SeverityLevel = request.Allergen.SeverityLevel;

            await dbContext.SaveChangesAsync();

            logger.LogInformation(
                "Successfully updated information for: {ingredientName}!", allergen.IngredientName
                );

            return allergen.ToModel();
    }

    public override async Task<DeleteAllergenResponse> DeleteAllergen(
DeleteAllergenRequest request,
ServerCallContext context)
    {
        var allergen = await dbContext.Allergens
            .FirstOrDefaultAsync(a => a.IngredientName == request.Allergen.IngredientName);

        if (allergen is null)
        {
            logger.LogInformation(
                "Product not found on database: {productName}!", request.Allergen.IngredientName
                );

            throw new RpcException(
                new Status(
                StatusCode.NotFound,
                "An error occurred, please try again later.")
                );
        }

        dbContext.Allergens.Remove(allergen);
        await dbContext.SaveChangesAsync();

        logger.LogInformation(
                "Successfully deleted: {ingredientName}!", request.Allergen.IngredientName
                );

        return new DeleteAllergenResponse { Succes = true };

    }

}
