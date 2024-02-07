using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps;

public class PurchaseMap : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Compra");
        builder.HasKey(purchase => purchase.Id);

        builder.Property(purchase => purchase.Id)
               .HasColumnName("IdCompra")
               .UseIdentityColumn();
        builder.Property(purchase => purchase.PersonId)
               .HasColumnName("IdPessoa");
        builder.Property(purchase => purchase.ProductId)
               .HasColumnName("IdProduto");
        builder.Property(purchase => purchase.Date)
               .HasColumnName("DataCompra");

        builder.HasOne(purchase => purchase.Person)
               .WithMany(person => person.Purchases);
        builder.HasOne(purchase => purchase.Product)
               .WithMany(product => product.Purchases);
    }
}
