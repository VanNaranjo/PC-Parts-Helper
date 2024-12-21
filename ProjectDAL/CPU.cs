using System;
using System.Collections.Generic;

namespace ProjectDAL;

public partial class CPU : ProjectEntity
{

    public string name { get; set; } = null!;

    public decimal? price { get; set; }

    public int core_count { get; set; }

    public decimal core_clock { get; set; }

    public decimal? boost_clock { get; set; }

    public int tdp { get; set; }

    public string? graphics { get; set; }

    public string smt { get; set; } = null!;
}
