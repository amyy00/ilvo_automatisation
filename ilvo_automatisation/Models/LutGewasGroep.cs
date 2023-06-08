using System.ComponentModel.DataAnnotations;

namespace ilvo_automatisation.Models;

public partial class LutGewasGroep
{
    [Key]
    public Guid Id { get; set; }

    public string Naam { get; set; } = null!;

    public Guid ToedieningsPlaatsId { get; set; }

    public Guid VersieId { get; set; }

    public int PrioriteitUitrijden1 { get; set; }

    public int PrioriteitUitrijden2 { get; set; }

    public virtual ICollection<LnkGewassen> LnkGewassen { get; set; } = new List<LnkGewassen>();

    public virtual LutToedieningsPlaat ToedieningsPlaats { get; set; } = null!;

    public virtual TblVersie Versie { get; set; } = null!;
}
