using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class UsuarioLogin
    {
        public UsuarioLogin()
        {
        }

        public long UsuarioLoginId { get; set; }
        public long UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Proveedor { get; set; }
        public string IdentificadorExterno { get; set; }
        public string Password { get; set; }
        public bool Validado { get; set; }
        public long? UsuarioAltaId { get; set; }
        public DateTime FechaAlta { get; set; }
        public long? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public long? UsuarioBajaId { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<LoginLog> LoginLog { get; set; }
    }
}
