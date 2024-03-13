using FluentValidation;

namespace App.DTOs.Validations;

public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("O campo Email é obrigatório e deve ser um email válido");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(5).WithMessage("O campo Senha é obrigatório e deve ter no mínimo 5 caracteres");
    }
}
