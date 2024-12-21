using System;
using System.Collections.Generic;

namespace ProjectDAL;

public partial class RAM : ProjectEntity
{

    public string name { get; set; } = null!;

    public decimal? price { get; set; }

    public string speed { get; set; } = null!;

    public string modules { get; set; } = null!;

    public decimal? price_per_gb { get; set; }

    public string? color { get; set; }

    public decimal first_word_latency { get; set; }

    public decimal cas_latency { get; set; }
}
