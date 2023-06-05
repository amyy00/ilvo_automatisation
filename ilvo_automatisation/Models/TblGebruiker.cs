using System;
using System.Collections.Generic;

namespace ilvo_automatisation.Models;

public partial class TblGebruiker
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SurName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Admin { get; set; }

    public virtual ICollection<TblVersie> TblVersies { get; set; } = new List<TblVersie>();
}
