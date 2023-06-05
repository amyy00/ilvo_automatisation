using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class GeoProvincie
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<GeoEmissieGemeente2019> GeoEmissieGemeente2019s { get; set; } = new List<GeoEmissieGemeente2019>();

    public virtual ICollection<GeoEmissieGemeente> GeoEmissieGemeentes { get; set; } = new List<GeoEmissieGemeente>();
}
