using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductSaleConfiguration : IEntityTypeConfiguration<ProductSale>
{
    public void Configure(EntityTypeBuilder<ProductSale> builder)
    {
        builder.ToTable("ProductSales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder
            .HasOne(x=> x.Sale)
            .WithMany(x => x.Products)
            .IsRequired();

        builder.Property(u => u.ProductId).IsRequired();
        builder.Property(u => u.Quantity).IsRequired();
        builder.Property(u => u.UnityPrice).IsRequired();
    }
}
