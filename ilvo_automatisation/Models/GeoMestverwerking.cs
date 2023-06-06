namespace ilvo_automatisation.Models;

public partial class GeoMestverwerking
{
    public long Id { get; set; }

    public long Uitbater { get; set; }

    public long Uitbating { get; set; }

    public int? Niscode { get; set; }

    public string Gemeente { get; set; } = null!;

    public DateTime? BeginDatum { get; set; }

    public DateTime? EindDatum { get; set; }
}
