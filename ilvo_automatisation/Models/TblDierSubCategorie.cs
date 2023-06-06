namespace ilvo_automatisation.Models;

public partial class TblDierSubCategorie
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int Weidedagen { get; set; }

    public Guid DierCategorieId { get; set; }

    public Guid VersieId { get; set; }

    public virtual LutDierCategorie DierCategorie { get; set; } = null!;

    public virtual ICollection<LnkStalDierSubCategorie> LnkStalDierSubCategories { get; set; } = new List<LnkStalDierSubCategorie>();

    public virtual ICollection<TblConvenant> TblConvenants { get; set; } = new List<TblConvenant>();

    public virtual ICollection<TblRegressieRechte> TblRegressieRechtes { get; set; } = new List<TblRegressieRechte>();

    public virtual ICollection<TblRegressie> TblRegressies { get; set; } = new List<TblRegressie>();

    public virtual TblVersie Versie { get; set; } = null!;
}
