using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class LnkKunstmest
{
    public Guid Id { get; set; }

    public int CodeMeststof { get; set; }

    public Guid KunstmestGroepId { get; set; }

    public Guid VersieId { get; set; }

    public virtual LutKunstmestGroep KunstmestGroep { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
