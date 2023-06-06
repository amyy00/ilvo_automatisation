namespace ilvo_automatisation.Models;

public partial class GeometryColumn
{
    public string FTableCatalog { get; set; } = null!;

    public string FTableSchema { get; set; } = null!;

    public string FTableName { get; set; } = null!;

    public string FGeometryColumn { get; set; } = null!;

    public int CoordDimension { get; set; }

    public int Srid { get; set; }

    public string GeometryType { get; set; } = null!;
}
