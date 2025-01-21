using System;
using System.Collections.Generic;

namespace WebServer.Entities;

public partial class MenuProduct
{
    public string Barcode { get; set; } = null!;

    public int CategoryId { get; set; }

    public string? AltTitle { get; set; }

    public string? AltDescription { get; set; }

    public string? Embedding { get; set; }

    public bool? Recommended { get; set; }

    public virtual Product BarcodeNavigation { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
