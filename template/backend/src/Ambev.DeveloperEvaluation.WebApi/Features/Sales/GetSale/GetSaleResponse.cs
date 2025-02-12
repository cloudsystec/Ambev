using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// API response model for GetSale operation
/// </summary>
public class GetSaleResponse
{
    /// <summary>
    /// the unique the Id. 
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// the CreatedAt time. 
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// the Customer Id
    /// </summary>
    public Guid CustomerId { get; set; } = Guid.Empty;

    /// <summary>
    /// The Total.
    /// </summary>
    public decimal Total => Products.Sum(x => x.Total);

    /// <summary>
    /// The Branch.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// The Product items
    /// </summary>
    public List<CreateSaleProductSaleRequest> Products { get; set; } = new List<CreateSaleProductSaleRequest>();

    /// <summary>
    /// The canceled Marker, true to canceled
    /// </summary>
    public bool Canceled { get; set; } = false;
}
