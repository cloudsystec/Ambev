using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.CustomerId).NotEmpty().WithMessage("The sale Customer Id must be placed.");
        RuleFor(sale => sale.Branch).NotEmpty().WithMessage("The sale Branch must be placed.");
        RuleForEach(sale => sale.Products).SetValidator(new ProductSaleValidator());
    }
}
