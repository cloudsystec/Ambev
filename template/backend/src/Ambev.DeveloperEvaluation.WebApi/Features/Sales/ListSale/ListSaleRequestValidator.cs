using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Validator for ListSaleRequest
/// </summary>
public class ListSaleRequestValidator : AbstractValidator<ListSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for ListSaleRequest
    /// </summary>
    public ListSaleRequestValidator()
    {
        //RuleFor(x => x.IdCustomer)
        //    .Empty()
        //    .WithMessage("Sale Number is required");
    }
}
