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
               .HasColumnName("Idcompra")
               .UseIdentityColumn();
        builder.Property(purchase => purchase.PersonId)
               .HasColumnName("Idpessoa");
        builder.Property(purchase => purchase.ProductId)
               .HasColumnName("Idproduto");
        builder.Property(purchase => purchase.Date)
               .HasColumnName("Datacompra");

        builder.HasOne(purchase => purchase.Person)
               .WithMany(person => person.Purchases);
        builder.HasOne(purchase => purchase.Product)
               .WithMany(product => product.Purchases);
    }
}
