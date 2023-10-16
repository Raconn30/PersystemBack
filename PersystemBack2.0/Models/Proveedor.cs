using System;
using System.Collections.Generic;

namespace PersystemBack2._0.Models;

public partial class Proveedor
{
    public string CodProveedor { get; set; } = null!;

    public string NomProveedor { get; set; } = null!;

    public string DirProveedor { get; set; } = null!;

    public string? TelProveedor { get; set; }
}
