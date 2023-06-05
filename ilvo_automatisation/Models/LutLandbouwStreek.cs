using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class LutLandbouwStreek
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid VersieId { get; set; }

    public virtual ICollection<LnkKunstmestGroepStreek> LnkKunstmestGroepStreeks { get; set; } = new List<LnkKunstmestGroepStreek>();

    public virtual TblVersie Versie { get; set; } = null!;
}
