using System;
using System.Collections.Generic;

namespace PersystemBack2._0.Models;

public partial class Contrato
{
    public string CodContrato { get; set; } = null!;

    public DateTime FechaInicioContr { get; set; }

    public DateTime FechaFinalContr { get; set; }

    public string CodSer { get; set; } = null!;

    public string NitPredio { get; set; } = null!;

    public double PrecioContrato { get; set; }

    public virtual Servicio CodSerNavigation { get; set; } = null!;

    public virtual Predio NitPredioNavigation { get; set; } = null!;

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
