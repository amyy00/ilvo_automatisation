using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class AangifteDierStalPa
{
    public long Id { get; set; }

    public decimal? JrProductie { get; set; }

    public long? NrLandbouwerFict { get; set; }

    public long? NrExploitantFict { get; set; }

    public long? NrExploitatieFict { get; set; }

    public decimal? NrVersie { get; set; }

    public string? CodeDiersoort { get; set; }

    public string? OmsDiersoort { get; set; }

    public string? CodeDiergroep { get; set; }

    public string? OmsDiergroep { get; set; }

    public string? CodeStaltype { get; set; }

    public string? OmsStaltype { get; set; }

    public string? OmsPasMaatregel { get; set; }

    public decimal? AanBezettingPasMaatregel { get; set; }
}
