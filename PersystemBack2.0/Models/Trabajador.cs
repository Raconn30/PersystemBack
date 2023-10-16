using System;
using System.Collections.Generic;

namespace PersystemBack2._0.Models;

public partial class Trabajador
{
    public string CedulaTrab { get; set; } = null!;

    public string NomTrab { get; set; } = null!;

    public string ApellTrab { get; set; } = null!;

    public string TelTrab { get; set; } = null!;

    public string DirTrab { get; set; } = null!;

    public string? CorreoTrab { get; set; }

    public double SalarioTrab { get; set; }

    public string CodContrato { get; set; } = null!;

    public virtual Contrato CodContratoNavigation { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
