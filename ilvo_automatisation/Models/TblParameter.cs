namespace ilvo_automatisation.Models;

public partial class TblParameter
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public double Waarde { get; set; }

    public Guid VersieId { get; set; }

    public virtual TblVersie Versie { get; set; } = null!;
}
