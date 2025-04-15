namespace AllergenCheck.Grpc.Entities;

public class Allergen
{
    public int Id { get; set; }
    public string IngredientName { get; set; } = string.Empty;
    public int SeverityLevel { get; set; }
    public string Descrip { get; set; } = string.Empty;
}
