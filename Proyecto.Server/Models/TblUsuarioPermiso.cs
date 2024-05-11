using System;
using System.Collections.Generic;

namespace Proyecto.Server.Models;

public partial class TblUsuarioPermiso
{
    public int UsuarioId { get; set; }

    public int PermisoId { get; set; }

    public bool? TienePermiso { get; set; }

    public virtual TblPermiso Permiso { get; set; } = null!;

    public virtual TblUsuario Usuario { get; set; } = null!;
}
