using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class TblStal1
{
    public int HistoryId { get; set; }

    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public string? Omschrijving { get; set; }

    public double FractieVloeibaar { get; set; }

    public double? ReductiePercentage { get; set; }

    public Guid MestTypeId { get; set; }

    public Guid StalTypeId { get; set; }

    public Guid VersieId { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Status { get; set; }
}
