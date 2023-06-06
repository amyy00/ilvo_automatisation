namespace ilvo_automatisation.Models;

public partial class LnkMestDierPlaat
{
    public Guid Id { get; set; }

    public Guid ToedieningsPlaatsId { get; set; }

    public Guid MestTypeId { get; set; }

    public Guid DierCategorieId { get; set; }

    public Guid VersieId { get; set; }

    public virtual LutDierCategorie DierCategorie { get; set; } = null!;

    public virtual LutMestType MestType { get; set; } = null!;

    public virtual LutToedieningsPlaat ToedieningsPlaats { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
