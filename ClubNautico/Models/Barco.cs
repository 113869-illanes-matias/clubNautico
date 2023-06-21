using System;
using System.Collections.Generic;

namespace ClubNautico.Models;

public partial class Barco
{
    public int Id { get; set; }

    public string? Modelo { get; set; }

    public int IdSocio { get; set; }

    public virtual Socio IdSocioNavigation { get; set; } = null!;
}
