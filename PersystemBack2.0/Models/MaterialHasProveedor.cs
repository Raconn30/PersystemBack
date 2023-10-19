using System;
using System.Collections.Generic;

namespace PersystemBack2._0.Models;

public partial class MaterialHasProveedor
{
    public string CodMat { get; set; } = null!;

    public string CodProveedor { get; set; } = null!;

    public virtual Material CodMatNavigation { get; set; } = null!;

    public virtual Proveedor CodProveedorNavigation { get; set; } = null!;
}
