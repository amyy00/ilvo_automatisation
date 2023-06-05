using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class TblVersie1
{
    public int HistoryId { get; set; }

    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid GebruikerId { get; set; }

    public bool Publiek { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Status { get; set; }
}
