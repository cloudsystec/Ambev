using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Validator for ListSaleCommand
/// </summary>
public class ListSaleValidator : AbstractValidator<ListSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for ListSaleCommand
    /// </summary>
    public ListSaleValidator()
    {
        //RuleFor(x => x.CustomerId)
        //    .NotEmpty()
        //    .WithMessage("Sale Number is required");
    }
}
