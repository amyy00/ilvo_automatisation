namespace ilvo_automatisation.Models;

public partial class LutStalType
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid VersieId { get; set; }

    public virtual ICollection<TblStal> TblStal { get; set; } = new List<TblStal>();

    public virtual TblVersie Versie { get; set; } = null!;
}
