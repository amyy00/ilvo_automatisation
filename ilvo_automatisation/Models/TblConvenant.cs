namespace ilvo_automatisation.Models;

public partial class TblConvenant
{
    public Guid Id { get; set; }

    public Guid DierSubCategorieId { get; set; }

    public double ConvenantMax { get; set; }

    public double ReductiePercentage { get; set; }

    public Guid VersieId { get; set; }

    public virtual TblDierSubCategorie DierSubCategorie { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
