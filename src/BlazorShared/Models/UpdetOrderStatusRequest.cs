using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorShared.Models.Order;

namespace BlazorShared.Models;
public class UpdetOrderStatusRequest
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}
