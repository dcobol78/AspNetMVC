﻿using System;
using System.Collections.Generic;

namespace Northwind.DataContext;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
