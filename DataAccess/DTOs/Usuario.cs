namespace DataAccess.DTOs
{
    public class UsuarioCrear
    {
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Perfil { get; set; }
        public UsuarioLoginCrear UsuarioLoginCrear { get; set; }
    }

    public class UsuarioEditar
    {
        public long UsuarioId { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Perfil { get; set; }
    }
}
