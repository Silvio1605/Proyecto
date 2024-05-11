using System;
using System.Collections.Generic;

namespace Proyecto.Server.Models;

public partial class TblUsuario
{
    public int IdUsuario { get; set; }

    public string? Correo { get; set; }

    public byte[]? Contraseña { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? UltimaConexion { get; set; }

    public int? IdRol { get; set; }

    public virtual TblRol? IdRolNavigation { get; set; }

    public virtual ICollection<TblUsuarioPermiso> TblUsuarioPermisos { get; set; } = new List<TblUsuarioPermiso>();
}
