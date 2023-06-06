namespace ilvo_automatisation.Models;

public partial class SpatialRefSy
{
    public int Srid { get; set; }

    public string? AuthName { get; set; }

    public int? AuthSrid { get; set; }

    public string? Srtext { get; set; }

    public string? Proj4text { get; set; }
}
