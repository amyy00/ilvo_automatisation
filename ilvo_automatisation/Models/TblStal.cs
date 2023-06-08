namespace ilvo_automatisation.Models;

public partial class TblStal
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public string? Omschrijving { get; set; }

    public double FractieVloeibaar { get; set; }

    public double? ReductiePercentage { get; set; }

    public Guid MestTypeId { get; set; }

    public Guid StalTypeId { get; set; }

    public Guid VersieId { get; set; }

    public virtual ICollection<LnkStalDierSubCategorie> LnkStalDierSubCategorie { get; set; } = new List<LnkStalDierSubCategorie>();

    public virtual LutMestType MestType { get; set; } = null!;

    public virtual LutStalType StalType { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
