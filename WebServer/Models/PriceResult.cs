namespace WebServer.Models;

public sealed class PriceResult
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public string? Description { get; set; }
    
    public Allergens Allergens { get; set; }
    
    public NutritionFacts? NutritionFacts { get; set; }
}