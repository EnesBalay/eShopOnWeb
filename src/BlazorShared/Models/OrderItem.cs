using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class OrderItem
{
    public int Id { get; set; }
    public CatalogItemOrdered ItemOrdered { get; set; }
    public decimal UnitPrice { get; set; }
    public int Units { get; set; }
}
