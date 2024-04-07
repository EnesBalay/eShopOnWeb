using System;
using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using static Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderDetailDto : OrderDto
{
    public List<OrderItem> OrderItems { get; set; }
}
