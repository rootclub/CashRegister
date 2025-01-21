namespace WebServer.Models;

public class Allergens
{
    public AllergensEnum Gluten { get; set; }

    public AllergensEnum Crustaceans { get; set; }

    public AllergensEnum Eggs { get; set; }

    public AllergensEnum Fish { get; set; }

    public AllergensEnum Peanuts { get; set; }

    public AllergensEnum Soy { get; set; }

    public AllergensEnum Milk { get; set; }

    public AllergensEnum Nuts { get; set; }

    public AllergensEnum Celery { get; set; }

    public AllergensEnum Sesame { get; set; }

    public AllergensEnum SulfurDioxide { get; set; }

    public AllergensEnum Lupin { get; set; }

    public AllergensEnum Mollusks { get; set; }
    
    public AllergensEnum Mustard { get; set; }
    
    public string? OtherAllergens { get; set; }
}