using System;
using System.Collections.Generic;

namespace PersystemBack2._0.Models;

public partial class Predio
{
    public string NitPredio { get; set; } = null!;

    public string NomPredio { get; set; } = null!;

    public int CuartosPredio { get; set; }

    public string TipoCuarto { get; set; } = null!;

    public string DirPredio { get; set; } = null!;

    public string CorreoPredio { get; set; } = null!;

    public string DocumentoRepre { get; set; } = null!;

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual Representante DocumentoRepreNavigation { get; set; } = null!;
}
