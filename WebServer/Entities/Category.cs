using System;
using System.Collections.Generic;

namespace WebServer.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? SortOrder { get; set; }

    public virtual ICollection<MenuProduct> MenuProducts { get; set; } = new List<MenuProduct>();
}
