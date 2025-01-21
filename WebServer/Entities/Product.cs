using System;
using System.Collections.Generic;

namespace WebServer.Entities;

public partial class Product
{
    public string Barcode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public string? Description { get; set; }

    public decimal? WeightVolume { get; set; }

    public string? WeightVolumeUnit { get; set; }
    
    public decimal Price { get; set; }

    public decimal VatType { get; set; }

    public decimal? Energy { get; set; }

    public decimal? TotalFat { get; set; }

    public decimal? SaturatedFat { get; set; }

    public decimal? TransFat { get; set; }

    public decimal? PolyunsaturatedFat { get; set; }

    public decimal? MonounsaturatedFat { get; set; }

    public decimal? Cholesterol { get; set; }

    public decimal? Sodium { get; set; }

    public decimal? TotalCarbs { get; set; }

    public decimal? DietaryFiber { get; set; }

    public decimal? SolubleFiber { get; set; }

    public decimal? TotalSugars { get; set; }

    public decimal? AddedSugars { get; set; }

    public decimal? VitaminD { get; set; }

    public decimal? Calcium { get; set; }

    public decimal? Iron { get; set; }

    public decimal? Potassium { get; set; }

    public decimal? VitaminA { get; set; }

    public decimal? VitaminC { get; set; }

    public decimal? Thiamin { get; set; }

    public decimal? Riboflavin { get; set; }

    public decimal? Niacin { get; set; }

    public decimal? VitaminB6 { get; set; }

    public decimal? Folate { get; set; }

    public decimal? VitaminB12 { get; set; }

    public decimal? Phosphorus { get; set; }

    public decimal? Magnesium { get; set; }

    public decimal? Zinc { get; set; }

    public decimal? Ethanol { get; set; }

    public short? Gluten { get; set; }

    public short? Crustaceans { get; set; }

    public short? Eggs { get; set; }

    public short? Fish { get; set; }

    public short? Peanuts { get; set; }

    public short? Soy { get; set; }

    public short? Milk { get; set; }

    public short? Nuts { get; set; }

    public short? Celery { get; set; }

    public short? Sesame { get; set; }

    public short? SulfurDioxide { get; set; }

    public short? Lupin { get; set; }

    public short? Mollusks { get; set; }
    
    public short? Mustard { get; set; }
    public string? OtherAllergens { get; set; }

    public virtual ICollection<InvTransaction> InvTransactions { get; set; } = new List<InvTransaction>();

    public virtual MenuProduct? MenuProduct { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
