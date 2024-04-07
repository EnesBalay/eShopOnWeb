using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;


namespace BlazorAdmin.Services;

public class OrderService : IOrderService
{
    private readonly HttpService _httpService;
    private readonly ILogger<OrderService> _logger;

    public OrderService(HttpService httpService, ILogger<OrderService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<Order> ChangeStatus(Order order)
    {
        var orderTask = _httpService.HttpPut<UpdateOrderResponse>($"order-status", order);
        await Task.WhenAll(orderTask);
        var newOrder = orderTask.Result.Order;
        return newOrder;
    }

    public async Task<OrderDetail> GetById(int id)
    {
        var orderTask = _httpService.HttpGet<DetailOrderResponse>($"orders/" + id);
        await Task.WhenAll(orderTask);
        var order = orderTask.Result.Order;
        return order;
    }

    public async Task<List<Order>> List()
    {
        _logger.LogInformation("Fetching orders from API.");

        var orderListTask = _httpService.HttpGet<ListOrderResponse>($"orders");
        await Task.WhenAll(orderListTask);
        var items = orderListTask.Result.Orders;
        return items;
    }
}
