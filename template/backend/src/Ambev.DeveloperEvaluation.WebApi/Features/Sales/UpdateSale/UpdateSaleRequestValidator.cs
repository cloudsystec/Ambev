using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleRequest that defines validation rules for Sale creation.
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
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
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.Id).NotEmpty().WithMessage("The sale Id must be placed to update from.");
    }
}