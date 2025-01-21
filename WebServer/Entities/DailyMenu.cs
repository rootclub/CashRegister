using System;
using System.Collections.Generic;

namespace WebServer.Entities;

public partial class DailyMenu
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Cost { get; set; }
}
