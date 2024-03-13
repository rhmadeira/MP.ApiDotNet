using Domain.Validations;

namespace Domain.Entities;

//sealed - Essa classe não poderá ser herdada.
public sealed class User
{
    public int Id { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    //Construtor privado para evitar que a classe seja instanciada sem os parâmetros obrigatórios.
    public User(string email, string password)
    {
        //Validações
        Validate(email, password);
    }

    //Construtor para quando eu for editar
    public User(int id, string email, string password)
    {
        DomainValidationException.When(id <= 0, "Invalid Id value");
        Id = id;
        Validate(email, password);
    }

    //Aqui eu faço a validação dos campos
    private void Validate(string email, string password)
    {
        DomainValidationException.When(string.IsNullOrEmpty(email), "Email is required");
        DomainValidationException.When(email.Length < 3, "Email too short");
        DomainValidationException.When(email.Length > 20, "Email too long");

        DomainValidationException.When(string.IsNullOrEmpty(password), "Password is required");
        DomainValidationException.When(password.Length < 5, "Password too short");
        DomainValidationException.When(password.Length > 50, "Password too long");

        //Após a validação, eu atribuo os valores aos campos
        Email = email;
        Password = password;
    }
}
