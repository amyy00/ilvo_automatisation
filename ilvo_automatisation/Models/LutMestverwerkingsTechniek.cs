namespace ilvo_automatisation.Models;

public partial class LutMestverwerkingsTechniek
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public double Ec { get; set; }

    public double? AandeelInVlaanderen { get; set; }

    public string? ZoekTermen { get; set; }

    public Guid VersieId { get; set; }

    public virtual TblVersie Versie { get; set; } = null!;
}
