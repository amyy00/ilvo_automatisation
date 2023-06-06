namespace ilvo_automatisation.Models;

public partial class LnkGewassen1
{
    public int HistoryId { get; set; }

    public Guid Id { get; set; }

    public int CodeHoofdTeelt { get; set; }

    public Guid GewasGroepId { get; set; }

    public Guid VersieId { get; set; }

    public string? OmsHoofdTeelt { get; set; }

    public Guid? GewasGroepOogstrestId { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Status { get; set; }
}
