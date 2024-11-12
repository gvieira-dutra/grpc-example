namespace AllergenCheck.Grpc.Entities;

public class Allergen
{
    public int Id { get; set; }
    public string IngredientName { get; set; }
    public int SeverityLevel { get; set; }
    public string Descrip { get; set; }
}
