using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class UpdateOrderStatusResponse : BaseResponse
{
    public UpdateOrderStatusResponse(Guid correlationId) : base(correlationId)
    {

    }
    public UpdateOrderStatusResponse()
    {
    }

    public OrderDto Order {  get; set; }
}
