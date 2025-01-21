using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebServer.Entities;

namespace WebServer.Context;

public partial class ProductsContext : DbContext
{
    public ProductsContext()
    {
    }

    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DailyMenu> DailyMenus { get; set; }

    public virtual DbSet<InvTransaction> InvTransactions { get; set; }

    public virtual DbSet<MenuProduct> MenuProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "pg_stat_statements");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(400)
                .HasColumnName("name");
            entity.Property(e => e.SortOrder).HasColumnName("sort_order");
        });

        modelBuilder.Entity<DailyMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("daily_menus_pkey");

            entity.ToTable("daily_menus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(400)
                .HasColumnName("title");
        });

        modelBuilder.Entity<InvTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("inv_transactions_pkey");

            entity.ToTable("inv_transactions");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Barcode)
                .HasMaxLength(100)
                .HasColumnName("barcode");
            entity.Property(e => e.CurrentQuantity).HasColumnName("current_quantity");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TransactionTimestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transaction_timestamp");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .HasColumnName("transaction_type");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.BarcodeNavigation).WithMany(p => p.InvTransactions)
                .HasForeignKey(d => d.Barcode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inv_transactions_barcode_fkey");
        });

        modelBuilder.Entity<MenuProduct>(entity =>
        {
            entity.HasKey(e => e.Barcode).HasName("menu_products_pkey");

            entity.ToTable("menu_products");

            entity.Property(e => e.Barcode)
                .HasMaxLength(100)
                .HasColumnName("barcode");
            entity.Property(e => e.AltDescription).HasColumnName("alt_description");
            entity.Property(e => e.AltTitle)
                .HasMaxLength(400)
                .HasColumnName("alt_title");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Embedding)
                .HasColumnType("jsonb")
                .HasColumnName("embedding");
            entity.Property(e => e.Recommended)
                .HasDefaultValue(false)
                .HasColumnName("recommended");

            entity.HasOne(d => d.BarcodeNavigation).WithOne(p => p.MenuProduct)
                .HasForeignKey<MenuProduct>(d => d.Barcode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menu_products_barcode_fkey");

            entity.HasOne(d => d.Category).WithMany(p => p.MenuProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menu_products_category_id_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Barcode).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Barcode)
                .HasMaxLength(100)
                .HasColumnName("barcode");
            entity.Property(e => e.AddedSugars)
                .HasPrecision(20, 10)
                .HasColumnName("added_sugars");
            entity.Property(e => e.Calcium)
                .HasPrecision(20, 10)
                .HasColumnName("calcium");
            entity.Property(e => e.Celery)
                .HasDefaultValue((short)0)
                .HasColumnName("celery");
            entity.Property(e => e.Cholesterol)
                .HasPrecision(20, 10)
                .HasColumnName("cholesterol");
            entity.Property(e => e.Crustaceans)
                .HasDefaultValue((short)0)
                .HasColumnName("crustaceans");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DietaryFiber)
                .HasPrecision(20, 10)
                .HasColumnName("dietary_fiber");
            entity.Property(e => e.Eggs)
                .HasDefaultValue((short)0)
                .HasColumnName("eggs");
            entity.Property(e => e.Energy)
                .HasPrecision(20, 10)
                .HasColumnName("energy");
            entity.Property(e => e.Ethanol)
                .HasPrecision(5, 2)
                .HasColumnName("ethanol");
            entity.Property(e => e.Fish)
                .HasDefaultValue((short)0)
                .HasColumnName("fish");
            entity.Property(e => e.Folate)
                .HasPrecision(20, 10)
                .HasColumnName("folate");
            entity.Property(e => e.Gluten)
                .HasDefaultValue((short)0)
                .HasColumnName("gluten");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Iron)
                .HasPrecision(20, 10)
                .HasColumnName("iron");
            entity.Property(e => e.Lupin)
                .HasDefaultValue((short)0)
                .HasColumnName("lupin");
            entity.Property(e => e.Magnesium)
                .HasPrecision(20, 10)
                .HasColumnName("magnesium");
            entity.Property(e => e.Milk)
                .HasDefaultValue((short)0)
                .HasColumnName("milk");
            entity.Property(e => e.Mollusks)
                .HasDefaultValue((short)0)
                .HasColumnName("mollusks");
            entity.Property(e => e.MonounsaturatedFat)
                .HasPrecision(20, 10)
                .HasColumnName("monounsaturated_fat");
            entity.Property(e => e.Mustard)
                .HasPrecision(20, 10)
                .HasColumnName("mustard");
            entity.Property(e => e.Name)
                .HasMaxLength(400)
                .HasColumnName("name");
            entity.Property(e => e.Niacin)
                .HasPrecision(20, 10)
                .HasColumnName("niacin");
            entity.Property(e => e.Nuts)
                .HasDefaultValue((short)0)
                .HasColumnName("nuts");
            entity.Property(e => e.OtherAllergens).HasColumnName("other_allergens");
            entity.Property(e => e.Peanuts)
                .HasDefaultValue((short)0)
                .HasColumnName("peanuts");
            entity.Property(e => e.Phosphorus)
                .HasPrecision(20, 10)
                .HasColumnName("phosphorus");
            entity.Property(e => e.PolyunsaturatedFat)
                .HasPrecision(20, 10)
                .HasColumnName("polyunsaturated_fat");
            entity.Property(e => e.Potassium)
                .HasPrecision(20, 10)
                .HasColumnName("potassium");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Riboflavin)
                .HasPrecision(20, 10)
                .HasColumnName("riboflavin");
            entity.Property(e => e.SaturatedFat)
                .HasPrecision(20, 10)
                .HasColumnName("saturated_fat");
            entity.Property(e => e.Sesame)
                .HasDefaultValue((short)0)
                .HasColumnName("sesame");
            entity.Property(e => e.Sodium)
                .HasPrecision(20, 10)
                .HasColumnName("sodium");
            entity.Property(e => e.SolubleFiber)
                .HasPrecision(20, 10)
                .HasColumnName("soluble_fiber");
            entity.Property(e => e.Soy)
                .HasDefaultValue((short)0)
                .HasColumnName("soy");
            entity.Property(e => e.SulfurDioxide)
                .HasDefaultValue((short)0)
                .HasColumnName("sulfur_dioxide");
            entity.Property(e => e.Thiamin)
                .HasPrecision(20, 10)
                .HasColumnName("thiamin");
            entity.Property(e => e.TotalCarbs)
                .HasPrecision(20, 10)
                .HasColumnName("total_carbs");
            entity.Property(e => e.TotalFat)
                .HasPrecision(20, 10)
                .HasColumnName("total_fat");
            entity.Property(e => e.TotalSugars)
                .HasPrecision(20, 10)
                .HasColumnName("total_sugars");
            entity.Property(e => e.TransFat)
                .HasPrecision(20, 10)
                .HasColumnName("trans_fat");
            entity.Property(e => e.VatType)
                .HasPrecision(5, 2)
                .HasColumnName("vat_type");
            entity.Property(e => e.VitaminA)
                .HasPrecision(20, 10)
                .HasColumnName("vitamin_a");
            entity.Property(e => e.VitaminB12)
                .HasPrecision(20, 10)
                .HasColumnName("vitamin_b12");
            entity.Property(e => e.VitaminB6)
                .HasPrecision(20, 10)
                .HasColumnName("vitamin_b6");
            entity.Property(e => e.VitaminC)
                .HasPrecision(20, 10)
                .HasColumnName("vitamin_c");
            entity.Property(e => e.VitaminD)
                .HasPrecision(20, 10)
                .HasColumnName("vitamin_d");
            entity.Property(e => e.WeightVolume)
                .HasPrecision(10, 2)
                .HasColumnName("weight_volume");
            entity.Property(e => e.WeightVolumeUnit)
                .HasMaxLength(10)
                .HasColumnName("weight_volume_unit");
            entity.Property(e => e.Zinc)
                .HasPrecision(20, 10)
                .HasColumnName("zinc");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tags_pkey");

            entity.ToTable("tags");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasMany(d => d.ProductBarcodes).WithMany(p => p.Tags)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductTag",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductBarcode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("product_tags_product_barcode_fkey"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("product_tags_tag_id_fkey"),
                    j =>
                    {
                        j.HasKey("TagId", "ProductBarcode").HasName("product_tags_pkey");
                        j.ToTable("product_tags");
                        j.IndexerProperty<int>("TagId").HasColumnName("tag_id");
                        j.IndexerProperty<string>("ProductBarcode")
                            .HasMaxLength(100)
                            .HasColumnName("product_barcode");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
