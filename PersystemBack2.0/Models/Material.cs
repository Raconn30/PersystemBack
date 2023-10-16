using System;
using System.Collections.Generic;

namespace PersystemBack2._0.Models;

public partial class Material
{
    public string CodMat { get; set; } = null!;

    public string NomMat { get; set; } = null!;

    public string TipoMat { get; set; } = null!;

    public double PrecioMat { get; set; }

    public string DesMat { get; set; } = null!;

    public string NumUnidades { get; set; } = null!;

    public DateTime FechaEntrada { get; set; }

    public DateTime FechaSalida { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
