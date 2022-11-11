using System;

namespace DataAccess.Models
{
    public partial class LoginLog
    {
        public long LoginLogId { get; set; }
        public long UsuarioLoginLogId { get; set; }
        public bool Exitoso { get; set; }
        public string Error { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual UsuarioLogin UsuarioLogin { get; set; }
    }
}
