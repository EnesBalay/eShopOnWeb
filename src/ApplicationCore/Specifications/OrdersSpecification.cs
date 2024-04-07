using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;
public class OrdersSpecification : Specification<Order>
{
    public OrdersSpecification()
    {
        Query.Include(o => o.OrderItems);
    }
   
}
