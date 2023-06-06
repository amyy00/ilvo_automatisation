namespace ilvo_automatisation.Models;

public partial class TblRegressie
{
    public Guid Id { get; set; }

    public Guid DierSubCategorieId { get; set; }

    public double RegressieMax { get; set; }

    public double ReductiePercentage { get; set; }

    public Guid VersieId { get; set; }

    public virtual TblDierSubCategorie DierSubCategorie { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
