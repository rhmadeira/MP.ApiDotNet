

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("usuario");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
               .HasColumnName("idusuario");
        builder.Property(x => x.Email)
               .HasColumnName("email")
               .IsRequired()
               .HasMaxLength(20);
        builder.Property(x => x.Password)
               .HasColumnName("senha")
               .IsRequired()
               .HasMaxLength(50);
    }
}
