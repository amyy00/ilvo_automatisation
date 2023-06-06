namespace ilvo_automatisation.Models;

public partial class MvwUitbatingActiviteit
{
    public long Id { get; set; }

    public decimal? JrProductie { get; set; }

    public long? UitbatersnummerFict { get; set; }

    public long? UitbatingsnummerFict { get; set; }

    public string? IndBiologie { get; set; }

    public string? IndCompdrog { get; set; }

    public string? IndPotgrond { get; set; }

    public string? IndSubstrt { get; set; }

    public string? IndChampi { get; set; }

    public string? IndTuinaan { get; set; }

    public string? IndVergist { get; set; }

    public string? AnderTypeActiviteit { get; set; }

    public string? IndNh4Spuiwater { get; set; }

    public string? IndNgasProductie { get; set; }
}
