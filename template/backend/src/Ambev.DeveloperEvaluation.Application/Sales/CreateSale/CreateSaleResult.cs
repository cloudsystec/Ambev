namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the response returned after successfully creating a new Sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSaleResult
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
    public decimal Total { get; set; } = 0;
}
