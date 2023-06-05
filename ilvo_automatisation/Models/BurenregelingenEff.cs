namespace ilvo_automatisation.Models;

public partial class BurenregelingenEff
{
    public long Id { get; set; }

    public DateTime? DaProc { get; set; }

    public int? JrBurenregeling { get; set; }

    public double? NrBurenregeling { get; set; }

    public string? CoRolAnb { get; set; }

    public long? NrLandbouwerAnbFict { get; set; }

    public long? NrExploitantAnbFict { get; set; }

    public long? NrExploitatieAnbFict { get; set; }

    public long? UitbatersnummerAnbFict { get; set; }

    public long? UitbatingsnummerAnbFict { get; set; }

    public string? CoRolAfn { get; set; }

    public long? NrLandbouwerAfnFict { get; set; }

    public long? NrExploitantAfnFict { get; set; }

    public long? NrExploitatieAfnFict { get; set; }

    public long? UitbatersnummerAfnFict { get; set; }

    public long? UitbatingsnummerAfnFict { get; set; }

    public string? CoNisGemeenteLospl { get; set; }

    public string? NmGemeenteLospl { get; set; }

    public int? CoMest { get; set; }

    public string? CoMesttype { get; set; }

    public string? CoMestvorm { get; set; }

    public double? GwKgN { get; set; }
}
