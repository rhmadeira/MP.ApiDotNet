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

    public Purchase(int productId, int personId)
    {
        Validate(productId, personId);
    }

    public Purchase(int id, int productId, int personId, DateTime? date)
    {
        DomainValidationException.When(id <= 0, "Invalid Id value");
        Id = id;
        Date = date ?? DateTime.Now;
        Validate(productId, personId);
    }
    public void Edit(int id, int productId, int personId)
    {
        DomainValidationException.When(id <= 0, "Invalid Id value");
        Id = id;
        Date = DateTime.Now;
        Validate(productId, personId);
    }

    public void Validate(int productId, int personId)
    {
        DomainValidationException.When(productId <= 0, "Id do produto inválido");
        DomainValidationException.When(personId <= 0, "Id da pessoa inválido");

        ProductId = productId;
        PersonId = personId;
        Date = DateTime.Now;
    }
}
