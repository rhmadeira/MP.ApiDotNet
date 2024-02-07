

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Produto");
        builder.HasKey(product => product.Id);

        builder.Property(product => product.Id)
               .HasColumnName("IdProduto")
               .UseIdentityColumn();

        builder.Property(product => product.Name)
               .HasColumnName("Nome");
        builder.Property(product => product.Price)
               .HasColumnName("Preco");
        builder.Property(product => product.CodErp)
               .HasColumnName("CodErp");

        builder.HasMany(product => product.Purchases)
               .WithOne(purchase => purchase.Product)
               .HasForeignKey(product => product.ProductId);
    }
}
