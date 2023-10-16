using System;
using System.Collections.Generic;

namespace PersystemBack2._0.Models;

public partial class Login
{
    public int CodUsuario { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string CedulaTrab { get; set; } = null!;

    public virtual Trabajador CedulaTrabNavigation { get; set; } = null!;
}
