using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class LnkKunstmestGroepStreek
{
    public Guid Id { get; set; }

    public double Ec { get; set; }

    public Guid KunstmestGroepId { get; set; }

    public Guid LandbouwStreekId { get; set; }

    public Guid VersieId { get; set; }

    public virtual LutKunstmestGroep KunstmestGroep { get; set; } = null!;

    public virtual LutLandbouwStreek LandbouwStreek { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
