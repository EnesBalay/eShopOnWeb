using Azure.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;
using AutoMapper;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using System.Linq;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderListEndpoint : IEndpoint<IResult, ListOrderRequest, IRepository<Order>>
{
    private readonly IMapper _mapper;

    public OrderListEndpoint(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders",
           async (IRepository<Order> orderRepository) =>
           {
               return await HandleAsync(new ListOrderRequest(),orderRepository);
           })
          .Produces<ListOrderResponse>()
          .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(ListOrderRequest request, IRepository<Order> orderRepository)
    {
        await Task.Delay(1000);
        var response = new ListOrderResponse(request.CorrelationId());
        var spec = new OrdersSpecification();
        var orders = await orderRepository.ListAsync(spec);
        response.Orders.AddRange(orders.Select(_mapper.Map<OrderDto>));

        return Results.Ok(response);
    }
}
