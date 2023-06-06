namespace ilvo_automatisation.Models;

public partial class TblPas1
{
    public int HistoryId { get; set; }

    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public double ReductiePercentage { get; set; }

    public bool Passtal { get; set; }

    public bool Pasvoeding { get; set; }

    public bool Pasweide { get; set; }

    public Guid VersieId { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Status { get; set; }

    public double? WeideUren { get; set; }

    public string? Staltype { get; set; }

    public double? Efnh3traditioneel { get; set; }
}
