using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class LnkGewassen
{
    public Guid Id { get; set; }

    public int CodeHoofdTeelt { get; set; }

    public Guid GewasGroepId { get; set; }

    public Guid VersieId { get; set; }

    public string? OmsHoofdTeelt { get; set; }

    public Guid? GewasGroepOogstrestId { get; set; }

    public virtual LutGewasGroep GewasGroep { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
