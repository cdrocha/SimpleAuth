using BusinessLogic;
using DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAuth.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly Autenticacion _autenticacionBO;
        private readonly Autorizacion _autorizacionBO;
        private long _usuarioLogueadoId;
        public AuthController(Autenticacion autenticacion, Autorizacion autorizacion)
        {
            _autenticacionBO = autenticacion;
            _autorizacionBO = autorizacion;
        }

        /// <summary>
        /// Dadas las credenciales de usuario, se devuelve un token de autenticación o un error en caso de fallar
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("login")]
        public ApiResult<string> Login(string usuario, string password)
        {
            return _autenticacionBO.Login(usuario, password);
        }

        [HttpGet("autorizar")]
        public ActionResult<ApiResult<bool>> Autorizar(string funcion)
        {
            string token = this.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(token))
                return new ApiResult<bool> { Success = false, Error = new ApiError { Codigo = 401, MensajeError = "Unauthorized" } };

            ApiResult<bool> apiResult = _autorizacionBO.EstaAutorizado(token, funcion, out _usuarioLogueadoId);

            if (apiResult.Success && apiResult.Value)
                return apiResult;
            else
                return Unauthorized(apiResult);
        }

        /// <summary>
        /// Una vez que el usuario es autorizado, este valor se guarda para saber quien es el usuario logueado.
        /// </summary>
        protected long UsuarioLogueadoId
        {
            get { return _usuarioLogueadoId; }
        }
    }
}
