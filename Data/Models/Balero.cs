using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Balero
{
    public int IdBaleros { get; set; }

    public string Marca { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public decimal Precio { get; set; }

    public DateTime? FechaCreate { get; set; }
}
