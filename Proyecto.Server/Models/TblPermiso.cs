using System;
using System.Collections.Generic;

namespace Proyecto.Server.Models;

public partial class TblPermiso
{
    public int IdPermiso { get; set; }

    public string? NombrePermiso { get; set; }

    public int? ModuloId { get; set; }

    public virtual TblModulo? Modulo { get; set; }

    public virtual ICollection<TblUsuarioPermiso> TblUsuarioPermisos { get; set; } = new List<TblUsuarioPermiso>();
}
