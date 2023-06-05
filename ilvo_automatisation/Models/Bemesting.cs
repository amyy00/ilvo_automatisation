using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class Bemesting
{
    public long Id { get; set; }

    public DateTime? DaProc { get; set; }

    public decimal? JrProductie { get; set; }

    public long? NrLandbouwerFict { get; set; }

    public long? NrExploitantFict { get; set; }

    public long? NrExploitatieFict { get; set; }

    public long? NrSeqPerceel { get; set; }

    public string? IdLbPerceel { get; set; }

    public decimal? OppHaNetto { get; set; }

    public int? CoGroepGewasMb { get; set; }

    public int? CoGroepGewasNMb { get; set; }

    public long? CoGewasHoofdteelt { get; set; }

    public string? OmsGroepGewasMb { get; set; }

    public string? OmsGroepGewasNMb { get; set; }

    public string? OmsGewasHoofdteelt { get; set; }

    public string? NmGemeenteBestand { get; set; }

    public string? OmsLandbouwstreek { get; set; }

    public decimal? XLabel { get; set; }

    public decimal? YLabel { get; set; }

    public string? NmGemeenteBestand1 { get; set; }

    public string? IndGebruik0101 { get; set; }

    public string? CoProductiemethode { get; set; }
}
