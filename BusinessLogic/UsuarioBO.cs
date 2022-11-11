using DataAccess;
using DataAccess.DTOs;

namespace BusinessLogic
{
    public class UsuarioBO
    {
        public UsuarioBO()
        {

        }

        /// <summary>
        /// Crea el usuario con su login, en caso de exito se devuelve el UsuarioId recien creado.
        /// </summary>
        /// <param name="usuarioLogueadoId"></param>
        /// <param name="usuarioCrear"></param>
        /// <returns></returns>
        public ApiResult<long> CrearUsuarioYLogin(long usuarioLogueadoId, UsuarioCrear usuarioCrear)
        {
            UsuarioData usuarioData = new UsuarioData();
            var resultado = usuarioData.Crear(usuarioLogueadoId, usuarioCrear);

            if (resultado.Success)
            {
                return new ApiResult<long> { Success = true, Value = resultado.Value.UsuarioId };
            }
            else
            {
                return new ApiResult<long> { Success = false, Error = resultado.Error };
            }
        }


        /// <summary>
        /// Asocia el rol al usuario y devuelve el id de la asociación creada.
        /// </summary>
        /// <param name="usuarioLogueadoId"></param>
        /// <param name="usuarioRolCrear"></param>
        /// <returns></returns>
        public ApiResult<long> AgregarRol(long usuarioLogueadoId, UsuarioRolCrear usuarioRolCrear)
        {
            UsuarioData usuarioData = new UsuarioData();
            var resultado = usuarioData.AgregarRol(usuarioLogueadoId, usuarioRolCrear);

            if (resultado.Success)
            {
                return new ApiResult<long> { Success = true, Value = resultado.Value.UsuarioRolId };
            }
            else
            {
                return new ApiResult<long> { Success = false, Error = resultado.Error };
            }
        }
    }
}
