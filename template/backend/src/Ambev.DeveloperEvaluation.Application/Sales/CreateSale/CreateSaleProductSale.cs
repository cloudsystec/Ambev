namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleProductSale
{
    public Guid ProductId { get; set; } = Guid.Empty;
    public int Quantity { get; set; } = 0;
    public decimal UnityPrice { get; set; } = 0;
    public decimal Discounts { get; set; } = 0;
    public decimal Total { get; set; } = 0;
}