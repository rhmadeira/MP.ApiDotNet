using Domain.Validations;

namespace Domain.Entities;

//sealed - Essa classe não poderá ser herdada.
public sealed class Person
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Phone { get; private set; }

    public ICollection<Purchase> Purchases { get; set; }
    
    //Construtor privado para evitar que a classe seja instanciada sem os parâmetros obrigatórios.
    public Person(string name, string document, string phone)
    {
        //Validações
        Validate(name, document, phone);
        Purchases = new List<Purchase>();
    }

    //Construtor para quando eu for editar
    public Person(int id, string name, string document, string phone)
    {
        DomainValidationException.When(id < 0, "Invalid Id value");
        Id = id;
        Validate(name, document, phone);
        Purchases = new List<Purchase>();
    }

    //Aqui eu faço a validação dos campos
    private void Validate(string name, string document, string phone)
    {
        DomainValidationException.When(string.IsNullOrEmpty(name), "Name is required");
        DomainValidationException.When(name.Length < 3, "Name too short");
        DomainValidationException.When(name.Length > 100, "Name too long");

        DomainValidationException.When(string.IsNullOrEmpty(document), "Document is required");
        DomainValidationException.When(document.Length < 11, "Document too short");
        DomainValidationException.When(document.Length > 14, "Document too long");

        DomainValidationException.When(string.IsNullOrEmpty(phone), "Phone is required");
        DomainValidationException.When(phone.Length < 8, "Phone too short");
        DomainValidationException.When(phone.Length > 11, "Phone too long");

        //Após a validação, eu atribuo os valores aos campos
        Name = name;
        Document = document;
        Phone = phone;
    }
}
