namespace ilvo_automatisation.Models;

public partial class GeoEmissieVlops1000
{
    public int Id { get; set; }

    public bool IsVlopsCel { get; set; }

    public long VlopsId { get; set; }

    public double Weide { get; set; }

    public double Stal { get; set; }

    public double Opslag { get; set; }

    public double Dierlijk { get; set; }

    public double Kunstmest { get; set; }

    public double MestVerw { get; set; }

    public double Totaal { get; set; }
}
