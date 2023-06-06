namespace ilvo_automatisation.Models;

public partial class LnkMestToedieningsEmissy
{
    public Guid Id { get; set; }

    public Guid MestTypeId { get; set; }

    public Guid DierCategorieId { get; set; }

    public int PrioriteitUitrijden { get; set; }

    public double MinNfractie { get; set; }

    public double Nitrificatiegraad { get; set; }

    public Guid VersieId { get; set; }

    public virtual LutDierCategorie DierCategorie { get; set; } = null!;

    public virtual LutMestType MestType { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
