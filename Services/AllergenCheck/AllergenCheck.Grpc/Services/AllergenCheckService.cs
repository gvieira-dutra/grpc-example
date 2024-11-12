using AllergenService.Grpc;

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
                "Ingredient not found on database");

            return new AllergenModel
            {
                IngredientName = "Not Found",
                SeverityLevel = 0,
                Descrip = "Not Found"
            };
        }

        logger.LogInformation(
            "Found ingredient: {IngredientName}", allergenInfo.IngredientName);

        return allergenInfo.ToModel();
    }
}
