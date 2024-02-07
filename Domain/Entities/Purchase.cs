using Domain.Validations;

namespace Domain.Entities;

public class Purchase
{
    public int Id { get; private set; }
    public int ProductId { get; private set; }
    public int PersonId { get; private set; }
    public DateTime Date { get; private set; }
    
    public Person Person { get; set; }
    public Product Product { get; set; }

    public Purchase(int productId, int personId, DateTime? date)
    {
        Validate(productId, personId, date);
    }

    public Purchase(int id, int productId, int personId, DateTime? date)
    {
        DomainValidationException.When(id < 0, "Invalid Id value");
        Id = id;
        Validate(productId, personId, date);
    }
    
    public void Validate(int productId, int personId, DateTime? date)
    {
        DomainValidationException.When(productId < 0, "Id do produto inválido");
        DomainValidationException.When(personId < 0, "Id da pessoa inválido");
        DomainValidationException.When(date == DateTime.MinValue, "data inválida");
        DomainValidationException.When(!date.HasValue, "data inválida");

        ProductId = productId;
        PersonId = personId;
        Date = date.Value;
    }
}
