using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infra.Data.Maps;

//Aqui você está declarando uma classe chamada PersonMap que implementa a interface IEntityTypeConfiguration<T> onde T é substituído pela sua entidade Person.
internal class PersonMap : IEntityTypeConfiguration<Person>
{

    //Este método é da interface IEntityTypeConfiguration<T> e você está implementando-o. Ele é chamado pelo EF Core para configurar as propriedades e relacionamentos da entidade Person.
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        //Aqui você está dizendo para o EF Core usar a tabela chamada "Pessoa" para mapear a entidade Person.
        builder.ToTable("Pessoa");
        //Você está configurando a chave primária da tabela Pessoa para ser a propriedade Id da entidade Person.
        builder.HasKey(c => c.Id);
        //Aqui você está mapeando as propriedades da entidade Person para as colunas da tabela Pessoa, usando o método HasColumnName para especificar os nomes das colunas na tabela do banco de dados.
        builder.Property(c => c.Id)
               .HasColumnName("IdPessoa")
               .UseIdentityColumn();
        builder.Property(c => c.Name)
               .HasColumnName("Nome");
        builder.Property(c => c.Document)
               .HasColumnName("Documento");
        builder.Property(c => c.Phone)
               .HasColumnName("Celular");

        builder.HasMany(person => person.Purchases)
               .WithOne(purchase => purchase.Person)
               .HasForeignKey(person => person.PersonId);


        //builder.HasMany(c => c.Purchases):
        //Aqui você está dizendo ao Entity Framework Core que a entidade Person tem muitas compras.
        //Isso é feito usando o método HasMany, indicando que a propriedade de navegação Purchases na entidade Person representa várias compras.

        //.WithOne(p => p.Person):
        //Este trecho especifica que cada compra(entidade Purchase) está associada a uma única pessoa(entidade Person).
        //Isso é feito usando o método WithOne, indicando que a propriedade de navegação Person na entidade Purchase representa uma pessoa.

        //.HasForeignKey(c => c.PersonId):
        //Aqui você está configurando a chave estrangeira para o relacionamento.
        //A chave estrangeira é uma propriedade na entidade Purchase que faz referência à chave primária da entidade Person.
        //Neste caso, você está dizendo que a propriedade PersonId na entidade Purchase é a chave estrangeira que se refere à chave primária da entidade Person.
    }
}
