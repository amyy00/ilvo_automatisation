namespace ilvo_automatisation.Models;

public partial class BuiVlaOpslverschil
{
    public long Id { get; set; }

    public DateTime? DaProc { get; set; }

    public int? JrProductie { get; set; }

    public long? NrLandbouwerFict { get; set; }

    public long? NrExploitantFict { get; set; }

    public long? NrExploitatieFict { get; set; }

    public double? GwKgNEigenafzetBuiVla { get; set; }

    public double? GwKgNGebruikDierBuiVla { get; set; }

    public double? GwKgNGebruikChemBuiVla { get; set; }

    public double? GwKgNOpslagverschilDier { get; set; }
}
