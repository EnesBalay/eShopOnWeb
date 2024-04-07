using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorAdmin.Pages.CatalogItemPage;
using Microsoft.eShopWeb.UnitTests.Builders;
using Xunit;
using static BlazorShared.Models.Order;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.OrderTests;
public class OrderStatusUpdate
{
    private readonly OrderStatus _pending = OrderStatus.pending;
    private readonly OrderStatus _approved = OrderStatus.approved;
    private readonly OrderStatus _submitted = OrderStatus.submitted;
    private readonly OrderStatus _cancelled = OrderStatus.cancelled;

    [Fact]
    public void IsApprovedStatus()
    {
        var order = new OrderBuilder().WithNoItems();
        order.UpdateOrderStatus(_approved);
        Assert.Equal(order.Status, _approved);
    }

    [Fact]
    public void IsPendingStatus()
    {
        var order = new OrderBuilder().WithNoItems();
        order.UpdateOrderStatus(_approved);
        order.UpdateOrderStatus(_pending);
        Assert.Equal(order.Status, _pending);
    }

    [Fact]
    public void IsSubmittedStatus()
    {
        var order = new OrderBuilder().WithNoItems();
        order.UpdateOrderStatus(_submitted);
        Assert.Equal(order.Status, _submitted);
    }

    [Fact]
    public void IsCancelledStatus()
    {
        var order = new OrderBuilder().WithNoItems();
        order.UpdateOrderStatus(_cancelled);
        Assert.Equal(order.Status, _cancelled);
    }
}
