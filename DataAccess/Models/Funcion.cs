using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Funcion
    {
        public Funcion()
        {
            RolFuncion = new HashSet<RolFuncion>();
        }

        public long FuncionId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public long UsuarioAltaId { get; set; }
        public DateTime FechaAlta { get; set; }
        public long? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public long? UsuarioBajaId { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual ICollection<RolFuncion> RolFuncion { get; set; }
    }
}
