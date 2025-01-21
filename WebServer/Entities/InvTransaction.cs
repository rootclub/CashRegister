using System;
using System.Collections.Generic;

namespace WebServer.Entities;

public partial class InvTransaction
{
    public int TransactionId { get; set; }

    public DateTime? TransactionTimestamp { get; set; }

    public string Barcode { get; set; } = null!;

    public string TransactionType { get; set; } = null!;

    public int Quantity { get; set; }

    public int CurrentQuantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public virtual Product BarcodeNavigation { get; set; } = null!;
}
