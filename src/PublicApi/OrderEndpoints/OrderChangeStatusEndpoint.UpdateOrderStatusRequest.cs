using static BlazorShared.Models.Order;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class UpdateOrderStatusRequest:BaseRequest
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}
