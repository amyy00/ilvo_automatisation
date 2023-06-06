namespace ilvo_automatisation.Models;

public partial class VervoerMad
{
    public long Id { get; set; }

    public DateTime? DatumAflading { get; set; }

    public int? JrVervoer { get; set; }

    public string? CoIdentEenhRolAanbieder { get; set; }

    public long? NrLandbouwerAnbFict { get; set; }

    public long? NrExploitantAnbFict { get; set; }

    public long? NrExploitatieAnbFict { get; set; }

    public long? UitbatingsnummerAnbFict { get; set; }

    public long? UitbatersnummerAnbFict { get; set; }

    public string? CoIdentEenhRolAfnemer { get; set; }

    public long? NrLandbouwerAfnFict { get; set; }

    public long? NrExploitantAfnFict { get; set; }

    public long? NrExploitatieAfnFict { get; set; }

    public long? UitbatersnummerAfnFict { get; set; }

    public long? UitbatingsnummerAfnFict { get; set; }

    public string? CoGewestLosplaats { get; set; }

    public int? CoMeststof { get; set; }

    public double? GwKgN { get; set; }

    public string? CoMestvorm { get; set; }

    public string? CoMesttype { get; set; }
}
