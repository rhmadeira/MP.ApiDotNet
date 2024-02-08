using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps;

public class PurchaseMap : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("compra");
        builder.HasKey(purchase => purchase.Id);

        builder.Property(purchase => purchase.Id)
               .HasColumnName("idcompra")
               .UseIdentityColumn();
        builder.Property(purchase => purchase.PersonId)
               .HasColumnName("idpessoa");
        builder.Property(purchase => purchase.ProductId)
               .HasColumnName("idproduto");
        builder.Property(purchase => purchase.Date)
               .HasColumnName("datacompra");

        builder.HasOne(purchase => purchase.Person)
               .WithMany(person => person.Purchases);
        builder.HasOne(purchase => purchase.Product)
               .WithMany(product => product.Purchases);
    }
}
