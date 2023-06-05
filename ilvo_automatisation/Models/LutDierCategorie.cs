using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class LutDierCategorie
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public string Code { get; set; } = null!;

    public Guid VersieId { get; set; }

    public virtual ICollection<LnkMestDierPlaat> LnkMestDierPlaats { get; set; } = new List<LnkMestDierPlaat>();

    public virtual ICollection<LnkMestToedieningsEmissy> LnkMestToedieningsEmissies { get; set; } = new List<LnkMestToedieningsEmissy>();

    public virtual ICollection<TblDierSubCategorie> TblDierSubCategories { get; set; } = new List<TblDierSubCategorie>();

    public virtual TblVersie Versie { get; set; } = null!;
}
