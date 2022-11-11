using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Usuario
    {
        public Usuario()
        {
            UsuarioLogin = new HashSet<UsuarioLogin>();
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public long UsuarioId { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Perfil { get; set; }
        public bool Activo { get; set; }
        public long UsuarioAltaId { get; set; }
        public DateTime FechaAlta { get; set; }
        public long? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public long? UsuarioBajaId { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual ICollection<UsuarioLogin> UsuarioLogin { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
