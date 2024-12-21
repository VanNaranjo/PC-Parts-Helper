using System;
using System.Collections.Generic;

namespace ProjectDAL;

public partial class InternalStorage : ProjectEntity
{

    public string name { get; set; } = null!;

    public decimal? price { get; set; }

    public decimal capacity { get; set; }

    public decimal? price_per_gb { get; set; }

    public string? type { get; set; }

    public int? cache { get; set; }

    public string form_factor { get; set; } = null!;

    public string _interface { get; set; } = null!;
}
