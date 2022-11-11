using System;

namespace DataAccess.Models
{
    public class UsuarioRol
    {
        public long UsuarioRolId { get; set; }
        public long UsuarioId { get; set; }
        public long RolId { get; set; }
        public bool Activo { get; set; }
        public long UsuarioAltaId { get; set; }
        public DateTime FechaAlta { get; set; }
        public long? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public long? UsuarioBajaId { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
