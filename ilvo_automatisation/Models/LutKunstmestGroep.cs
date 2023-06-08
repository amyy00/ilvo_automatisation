namespace ilvo_automatisation.Models;

public partial class LutKunstmestGroep
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid VersieId { get; set; }

    public virtual ICollection<LnkKunstmestGroepStreek> LnkKunstmestGroepStreek { get; set; } = new List<LnkKunstmestGroepStreek>();

    public virtual ICollection<LnkKunstmest> LnkKunstmest { get; set; } = new List<LnkKunstmest>();

    public virtual TblVersie Versie { get; set; } = null!;
}
