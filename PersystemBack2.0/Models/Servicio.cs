using System;
using System.Collections.Generic;

namespace PersystemBack2._0.Models;

public partial class Servicio
{
    public string CodSer { get; set; } = null!;

    public double PrecioSer { get; set; }

    public string DuracionSer { get; set; } = null!;

    public string NomSer { get; set; } = null!;

    public string DesSer { get; set; } = null!;

    public string TipoSer { get; set; } = null!;

    public string CodMat { get; set; } = null!;

    public virtual Material CodMatNavigation { get; set; } = null!;

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
