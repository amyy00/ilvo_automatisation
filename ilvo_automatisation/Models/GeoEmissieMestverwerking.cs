using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class GeoEmissieMestverwerking
{
    public int Id { get; set; }

    public long? Uitbating { get; set; }

    public long? Uitbater { get; set; }

    public string Gemeente { get; set; } = null!;

    public double? Emissie { get; set; }
}
