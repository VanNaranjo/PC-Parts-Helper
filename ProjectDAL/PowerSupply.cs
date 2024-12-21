using System;
using System.Collections.Generic;

namespace ProjectDAL;

public partial class PowerSupply : ProjectEntity
{

    public string name { get; set; } = null!;

    public decimal? price { get; set; }

    public string type { get; set; } = null!;

    public string? efficiency { get; set; }

    public int wattage { get; set; }

    public string modular { get; set; } = null!;

    public string? color { get; set; }
}
