using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for Sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - CustomerId: Must be valid Guid, is Required
    /// - Branch: is Required
    /// - Products: Must be a valid Object evaluated with ProductValidator
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.CustomerId).NotEmpty().WithMessage("The sale Customer Id must be placed.");
        RuleFor(sale => sale.Branch).NotEmpty().WithMessage("The sale Branch must be placed.");
        RuleForEach(sale => sale.Products).SetValidator(new CreateSaleProductSaleValidator());
    }
}