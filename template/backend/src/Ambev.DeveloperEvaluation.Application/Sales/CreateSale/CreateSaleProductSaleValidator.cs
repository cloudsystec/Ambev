using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using FluentValidation;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequestProduct that defines validation rules for Sale creation.
/// </summary>
public class CreateSaleProductSaleValidator : AbstractValidator<CreateSaleProductSale>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestProductValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ProductId: Must be valid Guid, is Required
    /// - Quantity: Required Valid Date
    /// - UnityPrice: Must be greater than 0, is Required
    /// - Discounts: Must be greater than 0, is Required
    /// </remarks>
    public CreateSaleProductSaleValidator()
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