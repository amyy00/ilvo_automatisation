namespace ilvo_automatisation.Models;

public partial class EvoaAanbieder
{
    public long Id { get; set; }

    public DateTime? DaProc { get; set; }

    public int? JrEvVervoer { get; set; }

    public long? NrLandbouwerAnbFict { get; set; }

    public long? NrExploitantAnbFict { get; set; }

    public long? NrExploitatieAnbFict { get; set; }

    public long? UitbatersnummerAanbiederFict { get; set; }

    public long? UitbatingsnummerAanbiederFict { get; set; }

    public string? CoIdentEenhRolAanbieder { get; set; }

    public int? CoMest { get; set; }

    public string? OmsMest { get; set; }

    public string? CoMesttype { get; set; }

    public string? CoMestvorm { get; set; }

    public string? NmMestvorm { get; set; }

    public double? GwKgNVnEvoaAfvoer { get; set; }
}
