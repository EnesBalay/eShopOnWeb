using System;
using static BlazorShared.Models.Order;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderDto
{
    public int Id { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public string BuyerId { get; set; }
    public OrderStatus Status { get; set; }
    public decimal Total { get; set; }
}
