using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleCommand that defines validation rules for Sale creation command.
/// </summary>
public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - CustomerId: Must be valid Guid, is Required
    /// - Branch: is Required
    /// - Products: Must be a valid Object evaluated with ProductValidator
    /// </remarks>
    public UpdateSaleCommandValidator()
    {
        RuleFor(sale => sale.Id).NotEmpty().WithMessage("The sale Id must be placed.");
        RuleFor(sale => sale.Canceled).NotEmpty().WithMessage("The sale cancel must be placed.");
    }
}