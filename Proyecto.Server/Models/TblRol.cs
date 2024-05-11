using System;
using System.Collections.Generic;

namespace Proyecto.Server.Models;

public partial class TblRol
{
    public int IdRol { get; set; }

    public string? DesRol { get; set; }

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}
