namespace ilvo_automatisation.Models;

public partial class TblCheck
{
    public Guid Id { get; set; }

    public string TabelNaam { get; set; } = null!;

    public string? KolomNaam { get; set; }

    public Guid CheckTypeId { get; set; }

    public Guid VersieId { get; set; }

    public virtual LutCheckType CheckType { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
