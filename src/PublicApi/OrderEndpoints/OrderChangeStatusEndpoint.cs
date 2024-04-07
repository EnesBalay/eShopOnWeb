using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderChangeStatusEndpoint : IEndpoint<IResult, UpdateOrderStatusRequest, IRepository<Order>>
{
    private readonly IMapper _mapper;
    public OrderChangeStatusEndpoint(IMapper mapper)
    {
        _mapper = mapper;
    }
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPut("api/order-status",
            [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] async (UpdateOrderStatusRequest request, IRepository<Order> orderRepository) =>
             {
                 return await HandleAsync(request, orderRepository);
             })
           .Produces<UpdateOrderStatusResponse>()
           .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(UpdateOrderStatusRequest request, IRepository<Order> orderRepository)
    {
        var response = new UpdateOrderStatusResponse(request.CorrelationId());

        var existingOrder = await orderRepository.GetByIdAsync(request.Id);
        if (existingOrder == null)
        {
            return Results.NotFound();
        }
        existingOrder.UpdateOrderStatus(request.Status);

        await orderRepository.UpdateAsync(existingOrder);

        OrderDto order = _mapper.Map<OrderDto>(existingOrder);
        response.Order = order;

        return Results.Ok(response);
    }
}
