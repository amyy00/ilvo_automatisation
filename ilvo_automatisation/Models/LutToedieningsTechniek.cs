using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class LutToedieningsTechniek
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid VersieId { get; set; }

    public virtual ICollection<LnkMestTechniekPlaat> LnkMestTechniekPlaats { get; set; } = new List<LnkMestTechniekPlaat>();

    public virtual TblVersie Versie { get; set; } = null!;
}
