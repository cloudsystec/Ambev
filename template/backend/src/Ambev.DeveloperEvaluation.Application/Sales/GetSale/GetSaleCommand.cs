using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a Sale by their Number
/// </summary>
public record GetSaleCommand : IRequest<GetSaleResult>
{
    /// <summary>
    /// The unique identifier of the Sale to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSaleCommand
    /// </summary>
    /// <param name="Id">The ID of the Sale to retrieve</param>
    public GetSaleCommand(Guid Id)
    {
        Id = Id;
    }
}
