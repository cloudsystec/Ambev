using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a ProductSale in the system with relationship information with Product and Sale.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class ProductSale : BaseEntity
{
    /// <summary>
    /// Gets the product Id
    /// </summary>
    public Guid ProductId { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets the sale id
    /// </summary>
    public Guid SaleId { get; set; } = Guid.Empty;
    public virtual Sale Sale { get; set; }

    /// <summary>
    /// Gets the quantity of the current Sale
    /// </summary>
    public int Quantity { get; set; } = 0;

    /// <summary>
    /// Gets the price of the unity
    /// </summary>
    public decimal UnityPrice { get; set; } = 0;

    /// <summary>
    /// Gets the discount in this specific product
    /// </summary>
    public decimal Discounts { get; set; } = 0;

    /// <summary>
    /// Initializes a new instance of the User class.
    /// </summary>
    public ProductSale()
    {
    }

    /// <summary>
    /// Performs validation of the ProductSale entity using the ProductSaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">ProductId required</list>
    /// <list type="bullet">Quantity greather than 0</list>
    /// <list type="bullet">UnityPrice greather than 0</list>
    /// <list type="bullet">Discounts</list>
    /// <list type="bullet">Total greather than 0</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new ProductSaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}