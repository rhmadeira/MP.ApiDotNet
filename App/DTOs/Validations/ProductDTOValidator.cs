using App.DTOS;
using FluentValidation;

namespace App.DTOs.Validations;

public class ProductDTOValidator : AbstractValidator<ProductDTO>
{
    public ProductDTOValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().NotNull().WithMessage("Nome é obrigatório")
            .MinimumLength(3).WithMessage("Nome muito pequeno")
            .MaximumLength(100).WithMessage("Nome muito grande");
        
        RuleFor(p => p.CodErp)
            .NotEmpty().NotNull().WithMessage("Codigo é obrigatório");
        
        RuleFor(p => p.Price)
            .NotEmpty().NotNull().WithMessage("Preço é obrigatório")
            .GreaterThan(0).WithMessage("Preço deve ser maior que zero");

    }
}
