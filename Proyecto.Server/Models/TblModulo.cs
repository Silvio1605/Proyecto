using System;
using System.Collections.Generic;

namespace Proyecto.Server.Models;

public partial class TblModulo
{
    public int IdModulo { get; set; }

    public string? NombreModulo { get; set; }

    public virtual ICollection<TblPermiso> TblPermisos { get; set; } = new List<TblPermiso>();
}
