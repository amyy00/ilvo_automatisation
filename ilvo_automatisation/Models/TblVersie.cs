namespace ilvo_automatisation.Models;

public partial class TblVersie
{
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid GebruikerId { get; set; }

    public bool Publiek { get; set; }

    public virtual TblGebruiker Gebruiker { get; set; } = null!;

    public virtual ICollection<LnkGewassen> LnkGewassen { get; set; } = new List<LnkGewassen>();

    public virtual ICollection<LnkKunstmestGroepStreek> LnkKunstmestGroepStreek { get; set; } = new List<LnkKunstmestGroepStreek>();

    public virtual ICollection<LnkKunstmest> LnkKunstmest { get; set; } = new List<LnkKunstmest>();

    public virtual ICollection<LnkMestDierPlaat> LnkMestDierPlaat { get; set; } = new List<LnkMestDierPlaat>();

    public virtual ICollection<LnkMestTechniekPlaat> LnkMestTechniekPlaat { get; set; } = new List<LnkMestTechniekPlaat>();

    public virtual ICollection<LnkMestToedieningsEmissy> LnkMestToedieningsEmissie { get; set; } = new List<LnkMestToedieningsEmissy>();

    public virtual ICollection<LnkStalDierSubCategorie> LnkStalDierSubCategorie { get; set; } = new List<LnkStalDierSubCategorie>();

    public virtual ICollection<LutCheckType> LutCheckType { get; set; } = new List<LutCheckType>();

    public virtual ICollection<LutDierCategorie> LutDierCategorie { get; set; } = new List<LutDierCategorie>();

    public virtual ICollection<LutGewasGroep> LutGewasGroep { get; set; } = new List<LutGewasGroep>();

    public virtual ICollection<LutKunstmestGroep> LutKunstmestGroep { get; set; } = new List<LutKunstmestGroep>();

    public virtual ICollection<LutLandbouwStreek> LutLandbouwStreek { get; set; } = new List<LutLandbouwStreek>();

    public virtual ICollection<LutMestType> LutMestType { get; set; } = new List<LutMestType>();

    public virtual ICollection<LutMestverwerkingsTechniek> LutMestverwerkingsTechniek { get; set; } = new List<LutMestverwerkingsTechniek>();

    public virtual ICollection<LutStalType> LutStalType { get; set; } = new List<LutStalType>();

    public virtual ICollection<LutToedieningsPlaat> LutToedieningsPlaat { get; set; } = new List<LutToedieningsPlaat>();

    public virtual ICollection<LutToedieningsTechniek> LutToedieningsTechniek { get; set; } = new List<LutToedieningsTechniek>();

    public virtual ICollection<TblCheck> TblCheck { get; set; } = new List<TblCheck>();

    public virtual ICollection<TblConvenant> TblConvenant { get; set; } = new List<TblConvenant>();

    public virtual ICollection<TblDierSubCategorie> TblDierSubCategorie { get; set; } = new List<TblDierSubCategorie>();

    public virtual ICollection<TblParameter> TblParameter { get; set; } = new List<TblParameter>();

    public virtual ICollection<TblPas> TblPas { get; set; } = new List<TblPas>();

    public virtual ICollection<TblRegressieRechte> TblRegressieRechte { get; set; } = new List<TblRegressieRechte>();

    public virtual ICollection<TblRegressie> TblRegressie { get; set; } = new List<TblRegressie>();

    public virtual ICollection<TblStal> TblStal { get; set; } = new List<TblStal>();
}
