using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;
public interface IOrderService
{
    Task<Order> ChangeStatus(Order order);
    Task<OrderDetail> GetById(int id);
    Task<List<Order>> List();
}
