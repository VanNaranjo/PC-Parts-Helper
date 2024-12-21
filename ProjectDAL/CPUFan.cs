using System;
using System.Collections.Generic;

namespace ProjectDAL;

public partial class CPUFan : ProjectEntity
{

    public string name { get; set; } = null!;

    public decimal? price { get; set; }

    public string? rpm { get; set; }

    public string? noise_level { get; set; }

    public string? color { get; set; }

    public int? size { get; set; }
}
