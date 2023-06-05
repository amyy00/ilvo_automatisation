namespace ilvo_automatisation.Models;

public partial class DierProd
{
    public long Id { get; set; }

    public DateTime? DaProc { get; set; }

    public decimal? JrProductie { get; set; }

    public long? NrLandbouwerFict { get; set; }

    public long? NrExploitantFict { get; set; }

    public long? NrExploitatieFict { get; set; }

    public string? CodeDiergroep { get; set; }

    public string? OmsDiergroep { get; set; }

    public string? CodeDiersoort { get; set; }

    public string? OmsDiersoort { get; set; }

    public string? CodeDiersoortMelkkoe { get; set; }

    public string? CodeNub { get; set; }

    public string? OmsNub { get; set; }

    public decimal? AanBezettingDiersoort { get; set; }

    public decimal? BrutoProductieN { get; set; }

    public decimal? EmissieverliesDiersoort { get; set; }

    public decimal? NettoProductieN { get; set; }
}
