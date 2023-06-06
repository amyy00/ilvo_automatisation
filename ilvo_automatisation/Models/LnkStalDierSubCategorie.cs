namespace ilvo_automatisation.Models;

public partial class LnkStalDierSubCategorie
{
    public Guid Id { get; set; }

    public Guid DierSubCategorieId { get; set; }

    public Guid StalId { get; set; }

    public double? AandeelInVlaanderen { get; set; }

    public double? Efnh3 { get; set; }

    public double? Ecn2ovm { get; set; }

    public double? Ecn2omm { get; set; }

    public double? Ecnovm { get; set; }

    public double? Ecnomm { get; set; }

    public double? Ecn2mm { get; set; }

    public double? Ecn2vm { get; set; }

    public double? Bezettingsgraad { get; set; }

    public string? MestNaam { get; set; }

    public string? Code { get; set; }

    public double? EcNh3Opslag { get; set; }

    public double? EcN2oOpslag { get; set; }

    public double? EcNoOpslag { get; set; }

    public double? EcN2Opslag { get; set; }

    public Guid VersieId { get; set; }

    public virtual TblDierSubCategorie DierSubCategorie { get; set; } = null!;

    public virtual TblStal Stal { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
