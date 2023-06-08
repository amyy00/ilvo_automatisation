namespace ilvo_automatisation.Models;

public partial class LutMestType
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid VersieId { get; set; }

    public virtual ICollection<LnkMestDierPlaat> LnkMestDierPlaat { get; set; } = new List<LnkMestDierPlaat>();

    public virtual ICollection<LnkMestTechniekPlaat> LnkMestTechniekPlaat { get; set; } = new List<LnkMestTechniekPlaat>();

    public virtual ICollection<LnkMestToedieningsEmissy> LnkMestToedieningsEmissie { get; set; } = new List<LnkMestToedieningsEmissy>();

    public virtual ICollection<TblStal> TblStal { get; set; } = new List<TblStal>();

    public virtual TblVersie Versie { get; set; } = null!;
}
