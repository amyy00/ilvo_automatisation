namespace ilvo_automatisation.Models;

public partial class MvwUitbatingAdressen
{
    public long Id { get; set; }

    public long? UitbatersnummerFict { get; set; }

    public long? UitbatingsnummerFict { get; set; }

    public string? StraatNrBusExploitatieUitbat { get; set; }

    public string? LandCoPostGemExploitatieUit { get; set; }

    public int? CoNisFusiegemeente { get; set; }

    public string? OmsFusiegemeente { get; set; }

    public DateTime? DaBeginIe { get; set; }

    public DateTime? DaEindeIe { get; set; }
}
