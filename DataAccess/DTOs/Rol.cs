namespace DataAccess.DTOs
{
    public class RolCrear
    {
        public string Nombre { get; set; }
    }

    public class RolEditar
    {
        public long RolId { get; set; }
        public string Nombre { get; set; }
    }

    public class RolEliminar
    {
        public long RolId { get; set; }
        public bool Activo { get; set; }
    }
}
