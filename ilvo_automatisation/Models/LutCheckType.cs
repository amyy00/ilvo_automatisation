namespace ilvo_automatisation.Models;

public partial class LutCheckType
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid VersieId { get; set; }

    public virtual ICollection<TblCheck> TblChecks { get; set; } = new List<TblCheck>();

    public virtual TblVersie Versie { get; set; } = null!;
}
