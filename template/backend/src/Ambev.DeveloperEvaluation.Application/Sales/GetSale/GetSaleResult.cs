using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
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
}
