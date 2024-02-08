using App.DTOS;
using FluentValidation;

namespace App.DTOs.Validations;

public class PersonDTOValidator : AbstractValidator<PersonDTO>
{
	public PersonDTOValidator()
	{
        RuleFor(p => p.Name)
            .NotEmpty().NotNull().WithMessage("Nome é obrigatório")
            .MinimumLength(3).WithMessage("Nome muito pequeno")
            .MaximumLength(100).WithMessage("Nome muito grande");

        RuleFor(p => p.Document)
            .NotEmpty().NotNull().WithMessage("Documento é obrigatório")
            .MinimumLength(11).WithMessage("Documento muito pequeno")
            .MaximumLength(14).WithMessage("Documento muito grande");

        RuleFor(p => p.Phone)
            .NotEmpty().NotNull().WithMessage("Telefone é obrigatório")
            .MinimumLength(8).WithMessage("Telefone muito pequeno")
            .MaximumLength(11).WithMessage("Telefone muito grande");
    }
}
