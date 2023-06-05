using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class GeoWeide
{
    public int Id { get; set; }

    public long? Exploitatie { get; set; }

    public long? Exploitant { get; set; }

    public long? Landbouwer { get; set; }

    public string Gemeente { get; set; } = null!;

    public double? Emissie { get; set; }
}
