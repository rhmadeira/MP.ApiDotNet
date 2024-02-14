using Domain.Validations;

namespace Domain.Entities;

public sealed class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string CodErp { get; private set; }
    public decimal Price { get; private set; }
    
    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public Product(string name, string codErp, decimal price)
    {
        Validate(name, codErp, price);
    }
    public Product(int id, string name, string codErp, decimal price)
    {
        DomainValidationException.When(id < 0, "Invalid Id value");
        Id = id;
        Validate(name, codErp, price);
    }
    private void Validate(string name, string codErp, decimal price)
    {
        DomainValidationException.When(string.IsNullOrEmpty(name), "Name is required");
        DomainValidationException.When(name.Length < 3, "Name too short");
        DomainValidationException.When(name.Length > 100, "Name too long");

        DomainValidationException.When(string.IsNullOrEmpty(codErp), "CodErp is required");
        DomainValidationException.When(codErp.Length < 3, "CodErp too short");
        DomainValidationException.When(codErp.Length > 20, "CodErp too long");

        DomainValidationException.When(price < 0, "Price is required");

        Name = name;
        CodErp = codErp;
        Price = price;
    }
    
}
