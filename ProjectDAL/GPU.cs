using System;
using System.Collections.Generic;

namespace ProjectDAL;

public partial class GPU : ProjectEntity
{

    public string name { get; set; } = null!;

    public decimal? price { get; set; }

    public string chipset { get; set; } = null!;

    public decimal memory { get; set; }

    public int? core_clock { get; set; }

    public int? boost_clock { get; set; }

    public string? color { get; set; }

    public int? length { get; set; }
}
