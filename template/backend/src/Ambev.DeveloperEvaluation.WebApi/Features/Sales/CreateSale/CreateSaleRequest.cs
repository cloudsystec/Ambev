using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new Sale in the system.
/// </summary>
public class CreateSaleRequest
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
    public List<CreateSaleProductSaleRequest> Products { get; set; } = new List<CreateSaleProductSaleRequest>();

    /// <summary>
    /// Gets or sets the Canceled.
    /// </summary>
    public bool Canceled { get; set; } = false;
}