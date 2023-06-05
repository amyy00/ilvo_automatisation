﻿using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class GeoEmissieVlops250
{
    public int Id { get; set; }

    public bool IsVlopsCel { get; set; }

    public long VlopsId { get; set; }

    public double Weide { get; set; }

    public double Stal { get; set; }

    public double Opslag { get; set; }

    public double Dierlijk { get; set; }

    public double Kunstmest { get; set; }

    public double MestVerw { get; set; }

    public double Totaal { get; set; }
}
