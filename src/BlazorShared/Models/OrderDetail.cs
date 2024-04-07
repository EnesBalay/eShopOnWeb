using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class OrderDetail:Order
{
    public List<OrderItem> OrderItems { get; set; }
}
