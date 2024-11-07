using System;
using System.Collections.Generic;

namespace IntroAsp.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Beer> Beers { get; set; } = new List<Beer>();
}
