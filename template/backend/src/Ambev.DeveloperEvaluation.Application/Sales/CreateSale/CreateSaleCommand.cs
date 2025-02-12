using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new Sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a Sale, 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    /// <summary>
    /// Gets or sets the Id. 
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the CreatedAt. 
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the Customer. Is required
    /// </summary>
    public Guid CustomerId { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets or sets the Total.
    /// </summary>
    public decimal Total => Products.Sum(x => x.Total);

    /// <summary>
    /// Gets or sets the Branch. Is required
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Products. Must contains almost one item
    /// </summary>
    public List<CreateSaleProductSale> Products { get; set; } = new List<CreateSaleProductSale>();

    /// <summary>
    /// Gets or sets the Canceled.
    /// </summary>
    public bool Canceled { get; set; } = false;

    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}