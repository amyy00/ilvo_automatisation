namespace ilvo_automatisation.Models;

public partial class LutToedieningsPlaat
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public double MaxNtotaalPerHa { get; set; }

    public Guid VersieId { get; set; }

    public virtual ICollection<LnkMestDierPlaat> LnkMestDierPlaat { get; set; } = new List<LnkMestDierPlaat>();

    public virtual ICollection<LnkMestTechniekPlaat> LnkMestTechniekPlaat { get; set; } = new List<LnkMestTechniekPlaat>();

    public virtual ICollection<LutGewasGroep> LutGewasGroep { get; set; } = new List<LutGewasGroep>();

    public virtual TblVersie Versie { get; set; } = null!;
}
