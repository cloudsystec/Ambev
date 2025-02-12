namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Request model for getting a Sale by Id
/// </summary>
public class ListSaleRequest
{
    /// <summary>
    /// The unique identifier of the Customer of Sale to retrieve
    /// </summary>
    public Guid? CustomerId { get; set; }
}
