using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Represents a request to Update a new Sale in the system.
/// </summary>
public class UpdateSaleRequest
{
    /// <summary>
    /// Gets or sets the Id for update from 
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the Canceled to cancel the order
    /// </summary>
    public bool Canceled { get; set; } = false;
}