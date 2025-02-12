using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Command for retrieving a Sale by their Number
/// </summary>
public record ListSaleCommand : IRequest<IQueryable<GetSaleResult>>
{
    /// <summary>
    /// The unique identifier of the Sale to retrieve
    /// </summary>
    public Guid CustomerId { get; }

    /// <summary>
    /// Initializes a new instance of ListSaleCommand
    /// </summary>
    /// <param name="customerId">The ID of the Sale to retrieve</param>
    public ListSaleCommand(Guid customerId)
    {
        CustomerId = customerId;
    }
}
