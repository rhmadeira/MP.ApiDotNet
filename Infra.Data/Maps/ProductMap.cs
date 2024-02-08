

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("produto");
        builder.HasKey(product => product.Id);

        builder.Property(product => product.Id)
               .HasColumnName("idproduto")
               .UseIdentityColumn();

        builder.Property(product => product.Name)
               .HasColumnName("nome");
        builder.Property(product => product.Price)
               .HasColumnName("preco");
        builder.Property(product => product.CodErp)
               .HasColumnName("coderp");

        builder.HasMany(product => product.Purchases)
               .WithOne(purchase => purchase.Product)
               .HasForeignKey(product => product.ProductId);
    }
}
