using MediatR;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Events;

public class SaleSaleModifiedEventHandler : INotificationHandler<SaleModifiedEvent>
{
    public Task Handle(SaleModifiedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[LOG] Sale was Modified: {notification.Sale.Id} | {DateTime.UtcNow}");
        return Task.CompletedTask;
    }
}