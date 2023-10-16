using System;
using System.Collections.Generic;

namespace PersystemBack2._0.Models;

public partial class Representante
{
    public string DocumentoRepre { get; set; } = null!;

    public string NomRepre { get; set; } = null!;

    public string ApellRepre { get; set; } = null!;

    public string TelRepre { get; set; } = null!;

    public string? CorreoRepre { get; set; }

    public string DiaAtencion { get; set; } = null!;

    public string HoraAtencion { get; set; } = null!;

    public virtual ICollection<Predio> Predios { get; set; } = new List<Predio>();
}
