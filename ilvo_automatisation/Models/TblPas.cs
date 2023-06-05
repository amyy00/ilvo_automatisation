using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class TblPas
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public double ReductiePercentage { get; set; }

    public bool Passtal { get; set; }

    public bool Pasvoeding { get; set; }

    public bool Pasweide { get; set; }

    public Guid VersieId { get; set; }

    public virtual TblVersie Versie { get; set; } = null!;
}
