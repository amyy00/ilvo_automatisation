namespace ilvo_automatisation.Models;

public partial class LutDierCategorie
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public string Code { get; set; } = null!;

    public Guid VersieId { get; set; }

    public virtual ICollection<LnkMestDierPlaat> LnkMestDierPlaat { get; set; } = new List<LnkMestDierPlaat>();

    public virtual ICollection<LnkMestToedieningsEmissy> LnkMestToedieningsEmissie { get; set; } = new List<LnkMestToedieningsEmissy>();

    public virtual ICollection<TblDierSubCategorie> TblDierSubCategorie { get; set; } = new List<TblDierSubCategorie>();

    public virtual TblVersie Versie { get; set; } = null!;
}
