namespace ilvo_automatisation.Models;

public partial class GeoEmissieGemeente2019
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public int NisCode { get; set; }

    public double Weide { get; set; }

    public double Stal { get; set; }

    public double Opslag { get; set; }

    public double Dierlijk { get; set; }

    public double Kunstmest { get; set; }

    public double Totaal { get; set; }

    public int ProvincieId { get; set; }

    public virtual GeoProvincie Provincie { get; set; } = null!;
}
