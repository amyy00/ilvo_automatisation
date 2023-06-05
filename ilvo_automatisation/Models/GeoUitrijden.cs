using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class GeoUitrijden
{
    public int Id { get; set; }

    public long? Exploitatie { get; set; }

    public long? Exploitant { get; set; }

    public long? Landbouwer { get; set; }

    public string Gemeente { get; set; } = null!;

    public double? Dierlijk { get; set; }

    public double? Kunstmest { get; set; }
}
