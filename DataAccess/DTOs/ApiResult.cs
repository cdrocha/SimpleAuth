namespace DataAccess.DTOs
{
    /// <summary>
    /// Clase para wrappear todas las respuestas y asi dar un manejo de errores unificado
    /// </summary>
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public ApiError Error { get; set; }
        public T Value { get; set; }
    }

    public class ApiError
    {
        /// <summary>
        /// Codigo de identificacion del error.
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Mensaje para el usuario
        /// </summary>
        public string MensajeError { get; set; }

        /// <summary>
        /// Mensaje detallado del error. Solo para uso de programadores que consuman la API.
        /// </summary>
        public string MensajeDebug { get; set; }
    }
}
