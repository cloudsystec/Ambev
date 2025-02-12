using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductSaleValidator : AbstractValidator<ProductSale>
{
    public ProductSaleValidator()
    {
        RuleFor(sale => sale.ProductId)
            .NotEmpty()
            .WithMessage("The id of a product must be placed.");

        RuleFor(sale => sale.Quantity)
            .GreaterThan(0)
            .WithMessage("The quantity of a product must be greater than zero.");

        RuleFor(sale => sale.UnityPrice)
            .GreaterThan(0)
            .WithMessage("The price of a product must be greater than zero.");

        RuleFor(sale => sale.Discounts)
            .GreaterThanOrEqualTo(0)
            .WithMessage("The discount of a product must be greater than or equal zero (must be a positive number).");
    }
}
