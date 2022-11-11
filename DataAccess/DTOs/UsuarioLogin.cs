namespace DataAccess.DTOs
{
    public class UsuarioLoginCrear
    {
        public long? UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Proveedor { get; set; }
        public string IdentificadorExterno { get; set; }
        public string Password { get; set; }
        public bool Validado { get; set; }
    }

    public class UsuarioLoginCambiarPassword
    {
        public long UsuarioLoginLogId { get; set; }
        public string PasswordAnterior { get; set; }
        public string PasswordActual { get; set; }
    }
}
