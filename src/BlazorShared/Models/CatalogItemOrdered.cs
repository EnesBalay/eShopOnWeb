using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class CatalogItemOrdered
{
    public int CatalogItemId { get;  set; }
    public string ProductName { get;  set; }
    public string PictureUri { get;  set; }
}
