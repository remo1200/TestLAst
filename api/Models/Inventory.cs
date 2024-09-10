using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Inventory
{
    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;
}
