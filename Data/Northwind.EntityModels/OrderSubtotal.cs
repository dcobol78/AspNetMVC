using System;
using System.Collections.Generic;

namespace AspNetMVC.Data.Northwind.EntityModels;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
