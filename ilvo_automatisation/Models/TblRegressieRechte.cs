namespace ilvo_automatisation.Models;

public partial class TblRegressieRechte
{
    public Guid Id { get; set; }

    public Guid DierSubCategorieId { get; set; }

    public double A { get; set; }

    public double B { get; set; }

    public Guid VersieId { get; set; }

    public virtual TblDierSubCategorie DierSubCategorie { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
