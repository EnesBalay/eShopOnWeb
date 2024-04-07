using System;

namespace BlazorShared.Models;
public class Order
{
    public int Id { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public string BuyerId { get; set; }
    public OrderStatus Status { get; set; }
    public decimal Total { get; set; }
    public enum OrderStatus
    {
        pending = 0,
        approved = 1,
        submitted = 2,
        cancelled = 3
    }
}
