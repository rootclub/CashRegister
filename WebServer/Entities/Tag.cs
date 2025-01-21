using System;
using System.Collections.Generic;

namespace WebServer.Entities;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> ProductBarcodes { get; set; } = new List<Product>();
}
