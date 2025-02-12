using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a Sale in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets or sets the CreatedAt. 
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the Customer. Is required
    /// </summary>
    public Guid CustomerId { get; set; } = Guid.Empty;
    public virtual Sale Customer { get; set; }

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
    public virtual IEnumerable<ProductSale> Products { get; set; } 

    /// <summary>
    /// Gets or sets the Canceled.
    /// </summary>
    public bool Canceled { get; set; } = false;

    /// <summary>
    /// Performs validation of the Sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Id: Must be valid Guid, is Required</list>
    /// <list type="bullet">Customer id: Must be valid Guid, is Required</list>
    /// <list type="bullet">Branch: is Required</list>
    /// <list type="bullet">Products: Must be a valid Object evaluated with ProductValidator</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Cancel the Sale account.
    /// Changes the Sale's status to Active.
    /// </summary>
    public void Cancel()
    {
        Canceled = true;
    }
}