using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderGetByIdEndpoint : IEndpoint<IResult, GetByIdOrderRequest, IRepository<Order>>
{

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders/{orderId}",
            async (int orderId, IRepository<Order> orderRepository) =>
            {
                return await HandleAsync(new GetByIdOrderRequest(orderId), orderRepository);
            })
            .Produces<GetByIdOrderResponse>()
            .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(GetByIdOrderRequest request, IRepository<Order> orderRepository)
    {
        var response = new GetByIdOrderResponse(request.CorrelationId());
        var spesification = new OrderWithItemsByIdSpec(request.OrderId);
        var order = await orderRepository.FirstOrDefaultAsync(spesification);
        if (order is null)
            return Results.NotFound();

        response.Order = new OrderDetailDto
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            BuyerId = order.BuyerId,
            OrderItems= order.OrderItems.ToList(),
            Status = order.Status,
            Total = order.Total()
        };
        return Results.Ok(response);
    }
}
