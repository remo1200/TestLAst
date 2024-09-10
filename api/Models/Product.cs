﻿using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Inventory? Inventory { get; set; }
}
