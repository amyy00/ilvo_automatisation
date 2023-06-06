namespace ilvo_automatisation.Models;

public partial class GebruikKm
{
    public long Id { get; set; }

    public long? NrLandbouwerFict { get; set; }

    public long? NrExploitantFict { get; set; }

    public long? NrExploitatieFict { get; set; }

    public int? JrProductie { get; set; }

    public int? CoMeststof { get; set; }

    public string? OmsMeststofLang { get; set; }

    public string? CoMesttype { get; set; }

    public double? GwKgN { get; set; }

    public double? GwKgP { get; set; }

    public string? IndSerre { get; set; }
}
