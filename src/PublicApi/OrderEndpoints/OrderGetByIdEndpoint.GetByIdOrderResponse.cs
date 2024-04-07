using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class GetByIdOrderResponse : BaseResponse
{
    public GetByIdOrderResponse(Guid correlationId) : base(correlationId) 
    {
    }
    public GetByIdOrderResponse() 
    { 
    }

    public OrderDetailDto Order { get; set; }
}
