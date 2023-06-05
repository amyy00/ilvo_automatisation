using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class LnkMestTechniekPlaat
{
    public Guid Id { get; set; }

    public double? Ec { get; set; }

    public double? AandeelInVlaanderen { get; set; }

    public Guid? ToedieningsPlaatsId { get; set; }

    public Guid? MestTypeId { get; set; }

    public Guid? ToedieningsTechniekId { get; set; }

    public Guid VersieId { get; set; }

    public virtual LutMestType? MestType { get; set; }

    public virtual LutToedieningsPlaat? ToedieningsPlaats { get; set; }

    public virtual LutToedieningsTechniek? ToedieningsTechniek { get; set; }

    public virtual TblVersie Versie { get; set; } = null!;
}
