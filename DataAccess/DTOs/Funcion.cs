namespace DataAccess.DTOs
{
    public class FuncionCrear
    {
        public string Nombre { get; set; }
    }

    /// <summary>
    /// Solo el nombre se puede editar
    /// </summary>
    public class FuncionEditar
    {
        public long FuncionId { get; set; }
        public string Nombre { get; set; }
    }

    public class FuncionEliminar
    {
        public FuncionEliminar()
        {
        }

        public long FuncionId { get; set; }
        public bool Activo { get; set; }
    }
}
