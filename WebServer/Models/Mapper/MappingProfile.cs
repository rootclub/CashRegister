using System.Resources;
using AutoMapper;

namespace WebServer.Models.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map from Entities.Product to Models.PriceResult
        CreateMap<Entities.Product, Models.PriceResult>()
            .ForMember(dest => dest.Allergens, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.NutritionFacts, opt => opt.MapFrom(src => src));
        // Map from Entities.Product to Models.NutritionFacts
        CreateMap<Entities.Product, Models.NutritionFacts?>()
            // If all fields on source are null, return null instead of mapping
            .ConvertUsing<ProductToNullableResolver>();
        // Map from Entities.Product to Models.Allergens
        CreateMap<Entities.Product, Models.Allergens>()
            .ForMember(dest => dest.OtherAllergens, opt => opt.MapFrom(src => src.OtherAllergens))
            .ForMember(dest => dest.Gluten, opt => opt.MapFrom(src => (AllergensEnum)src.Gluten))
            .ForMember(dest => dest.Crustaceans, opt => opt.MapFrom(src => (AllergensEnum)src.Crustaceans))
            .ForMember(dest => dest.Eggs, opt => opt.MapFrom(src => (AllergensEnum)src.Eggs))
            .ForMember(dest => dest.Fish, opt => opt.MapFrom(src => (AllergensEnum)src.Fish))
            .ForMember(dest => dest.Peanuts, opt => opt.MapFrom(src => (AllergensEnum)src.Peanuts))
            .ForMember(dest => dest.Soy, opt => opt.MapFrom(src => (AllergensEnum)src.Soy))
            .ForMember(dest => dest.Milk, opt => opt.MapFrom(src => (AllergensEnum)src.Milk))
            .ForMember(dest => dest.Nuts, opt => opt.MapFrom(src => (AllergensEnum)src.Nuts))
            .ForMember(dest => dest.Celery, opt => opt.MapFrom(src => (AllergensEnum)src.Celery))
            .ForMember(dest => dest.Sesame, opt => opt.MapFrom(src => (AllergensEnum)src.Sesame))
            .ForMember(dest => dest.SulfurDioxide, opt => opt.MapFrom(src => (AllergensEnum)src.SulfurDioxide))
            .ForMember(dest => dest.Lupin, opt => opt.MapFrom(src => (AllergensEnum)src.Lupin))
            .ForMember(dest => dest.Mollusks, opt => opt.MapFrom(src => (AllergensEnum)src.Mollusks))
            .ForMember(dest => dest.Mustard, opt => opt.MapFrom(src => (AllergensEnum)src.Mustard));
    }
}

public class ProductToNullableResolver : ITypeConverter<Entities.Product, Models.NutritionFacts?>
{
    public Models.NutritionFacts? Convert(Entities.Product source, Models.NutritionFacts? destination, ResolutionContext context)
    {
        // Check if all nutrition-related fields are null
        bool allFieldsNull =
            source.WeightVolume == null &&
            source.WeightVolumeUnit == null &&
            source.Energy == null &&
            source.TotalFat == null &&
            source.SaturatedFat == null &&
            source.TransFat == null &&
            source.PolyunsaturatedFat == null &&
            source.MonounsaturatedFat == null &&
            source.Cholesterol == null &&
            source.Sodium == null &&
            source.TotalCarbs == null &&
            source.DietaryFiber == null &&
            source.SolubleFiber == null &&
            source.TotalSugars == null &&
            source.AddedSugars == null &&
            source.VitaminD == null &&
            source.Calcium == null &&
            source.Iron == null &&
            source.Potassium == null &&
            source.VitaminA == null &&
            source.VitaminC == null &&
            source.Thiamin == null &&
            source.Riboflavin == null &&
            source.Niacin == null &&
            source.VitaminB6 == null &&
            source.Folate == null &&
            source.VitaminB12 == null &&
            source.Phosphorus == null &&
            source.Magnesium == null &&
            source.Zinc == null &&
            source.Ethanol == null;

        // If all fields are null, return null
        if (allFieldsNull)
        {
            return null;
        }

        // Otherwise, map the source to NutritionFacts
        return new Models.NutritionFacts
        {
            WeightVolume = source.WeightVolume,
            WeightVolumeUnit = source.WeightVolumeUnit,
            Energy = source.Energy,
            TotalFat = source.TotalFat,
            SaturatedFat = source.SaturatedFat,
            TransFat = source.TransFat,
            PolyunsaturatedFat = source.PolyunsaturatedFat,
            MonounsaturatedFat = source.MonounsaturatedFat,
            Cholesterol = source.Cholesterol,
            Sodium = source.Sodium,
            TotalCarbs = source.TotalCarbs,
            DietaryFiber = source.DietaryFiber,
            SolubleFiber = source.SolubleFiber,
            TotalSugars = source.TotalSugars,
            AddedSugars = source.AddedSugars,
            VitaminD = source.VitaminD,
            Calcium = source.Calcium,
            Iron = source.Iron,
            Potassium = source.Potassium,
            VitaminA = source.VitaminA,
            VitaminC = source.VitaminC,
            Thiamin = source.Thiamin,
            Riboflavin = source.Riboflavin,
            Niacin = source.Niacin,
            VitaminB6 = source.VitaminB6,
            Folate = source.Folate,
            VitaminB12 = source.VitaminB12,
            Phosphorus = source.Phosphorus,
            Magnesium = source.Magnesium,
            Zinc = source.Zinc,
            Ethanol = source.Ethanol
        };
    }
}

