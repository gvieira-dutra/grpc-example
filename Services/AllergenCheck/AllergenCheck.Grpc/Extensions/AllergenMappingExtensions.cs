using AllergenService.Grpc;

namespace AllergenCheck.Grpc.Extensions;

public static class AllergenMappingExtensions
{
    public static AllergenModel ToModel(this Allergen allergen)
    {
        return new AllergenModel
        {
            IngredientName = allergen.IngredientName,
            SeverityLevel = allergen.SeverityLevel,
            Descrip = allergen.Descrip
        };
    }
}
