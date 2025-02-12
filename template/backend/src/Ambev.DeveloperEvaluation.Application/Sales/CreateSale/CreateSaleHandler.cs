using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The Sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IMediator mediator)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Sale details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingSale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingSale != null)
            throw new InvalidOperationException($"Sale with number {command.Id} already exists");

        if (!command.Products.Any())
            throw new InvalidOperationException($"Sale must contain products");

        //It's not possible to sell above 20 identical items
        if (command.Products.Any(x=> x.Quantity > 20))
            throw new InvalidOperationException($"all products at this sale must contain less than 20 identical itens.");

        CheckDiscount(command);

        var sale = _mapper.Map<Sale>(command);

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        //the event of created sale
        await _mediator.Publish(new SaleCreatedEvent(createdSale));

        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }

    //Purchases above 4 identical items have a 10% discount
    //Purchases between 10 and 20 identical items have a 20% discount
    //Purchases below 4 items cannot have a discount
    public void CheckDiscount(CreateSaleCommand command)
    {
        var productDiscount = command.Products.Where(x => x.Quantity > 4);

        foreach (var product in productDiscount)
            product.Discounts = product.Quantity < 10 ? 10 : product.Quantity < 20 ? 20 : 0;

        //Purchases below 4 items cannot have a discount
        productDiscount = command.Products.Where(x => x.Quantity < 4);
        foreach (var product in productDiscount)
            product.Discounts = 0;
    }
}
