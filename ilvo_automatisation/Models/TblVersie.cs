using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class TblVersie
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid GebruikerId { get; set; }

    public bool Publiek { get; set; }

    public virtual TblGebruiker Gebruiker { get; set; } = null!;

    public virtual ICollection<LnkGewassen> LnkGewassens { get; set; } = new List<LnkGewassen>();

    public virtual ICollection<LnkKunstmestGroepStreek> LnkKunstmestGroepStreeks { get; set; } = new List<LnkKunstmestGroepStreek>();

    public virtual ICollection<LnkKunstmest> LnkKunstmests { get; set; } = new List<LnkKunstmest>();

    public virtual ICollection<LnkMestDierPlaat> LnkMestDierPlaats { get; set; } = new List<LnkMestDierPlaat>();

    public virtual ICollection<LnkMestTechniekPlaat> LnkMestTechniekPlaats { get; set; } = new List<LnkMestTechniekPlaat>();

    public virtual ICollection<LnkMestToedieningsEmissy> LnkMestToedieningsEmissies { get; set; } = new List<LnkMestToedieningsEmissy>();

    public virtual ICollection<LnkStalDierSubCategorie> LnkStalDierSubCategories { get; set; } = new List<LnkStalDierSubCategorie>();

    public virtual ICollection<LutCheckType> LutCheckTypes { get; set; } = new List<LutCheckType>();

    public virtual ICollection<LutDierCategorie> LutDierCategories { get; set; } = new List<LutDierCategorie>();

    public virtual ICollection<LutGewasGroep> LutGewasGroeps { get; set; } = new List<LutGewasGroep>();

    public virtual ICollection<LutKunstmestGroep> LutKunstmestGroeps { get; set; } = new List<LutKunstmestGroep>();

    public virtual ICollection<LutLandbouwStreek> LutLandbouwStreeks { get; set; } = new List<LutLandbouwStreek>();

    public virtual ICollection<LutMestType> LutMestTypes { get; set; } = new List<LutMestType>();

    public virtual ICollection<LutMestverwerkingsTechniek> LutMestverwerkingsTechnieks { get; set; } = new List<LutMestverwerkingsTechniek>();

    public virtual ICollection<LutStalType> LutStalTypes { get; set; } = new List<LutStalType>();

    public virtual ICollection<LutToedieningsPlaat> LutToedieningsPlaats { get; set; } = new List<LutToedieningsPlaat>();

    public virtual ICollection<LutToedieningsTechniek> LutToedieningsTechnieks { get; set; } = new List<LutToedieningsTechniek>();

    public virtual ICollection<TblCheck> TblChecks { get; set; } = new List<TblCheck>();

    public virtual ICollection<TblConvenant> TblConvenants { get; set; } = new List<TblConvenant>();

    public virtual ICollection<TblDierSubCategorie> TblDierSubCategories { get; set; } = new List<TblDierSubCategorie>();

    public virtual ICollection<TblParameter> TblParameters { get; set; } = new List<TblParameter>();

    public virtual ICollection<TblPas> TblPas { get; set; } = new List<TblPas>();

    public virtual ICollection<TblRegressieRechte> TblRegressieRechtes { get; set; } = new List<TblRegressieRechte>();

    public virtual ICollection<TblRegressie> TblRegressies { get; set; } = new List<TblRegressie>();

    public virtual ICollection<TblStal> TblStals { get; set; } = new List<TblStal>();
}
