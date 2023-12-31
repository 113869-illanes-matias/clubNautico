﻿using System;
using System.Collections.Generic;

namespace ClubNautico.Models;

public partial class Socio
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public virtual ICollection<Barco> Barcos { get; set; } = new List<Barco>();
}
