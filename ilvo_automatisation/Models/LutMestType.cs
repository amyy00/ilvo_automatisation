namespace ilvo_automatisation.Models;

public partial class LutMestType
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid VersieId { get; set; }

    public virtual ICollection<LnkMestDierPlaat> LnkMestDierPlaats { get; set; } = new List<LnkMestDierPlaat>();

    public virtual ICollection<LnkMestTechniekPlaat> LnkMestTechniekPlaats { get; set; } = new List<LnkMestTechniekPlaat>();

    public virtual ICollection<LnkMestToedieningsEmissy> LnkMestToedieningsEmissies { get; set; } = new List<LnkMestToedieningsEmissy>();

    public virtual ICollection<TblStal> TblStals { get; set; } = new List<TblStal>();

    public virtual TblVersie Versie { get; set; } = null!;
}
