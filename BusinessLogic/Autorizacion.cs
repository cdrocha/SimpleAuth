using BusinessLogic.DTOs;
using BusinessLogic.Helpers;
using DataAccess;
using DataAccess.DTOs;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BusinessLogic
{
    /// <summary>
    /// Esta clase maneja la autorizacion
    /// </summary>
    public class Autorizacion
    {
        private readonly IConfiguration _config;

        public Autorizacion(IConfiguration config)
        {
            _config = config;
        }


        /// <summary>
        /// Se valida que el token no haya sido adulterado, se busca al usuario dueño del token y por ultimo se verifica si ese usuario puede acceder a la funcion pedida.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="funcion"></param>
        /// <returns></returns>
        public ApiResult<bool> EstaAutorizado(string token, string funcion, out long UsuarioLogueadoId)
        {
            TokenCrearDTO tokenCrearDTO = new TokenCrearDTO();

            // appsetting for Token JWT

            tokenCrearDTO.secretKey = _config.GetValue<string>("TokenConfiguration:JWT_SECRET_KEY");
            tokenCrearDTO.audienceToken = _config.GetValue<string>("TokenConfiguration:JWT_AUDIENCE_TOKEN");
            tokenCrearDTO.issuerToken = _config.GetValue<string>("TokenConfiguration:JWT_ISSUER_TOKEN");
            tokenCrearDTO.expireTimeInMinutes = _config.GetValue<int>("TokenConfiguration:JWT_EXPIRE_MINUTES");

            long loginId = 0;
            UsuarioLogueadoId = -1;
            try
            {
                loginId = TokenHelper.ValidarYObtenerIdentitdad(token.Replace("Bearer ", ""), tokenCrearDTO);
            }
            catch (System.Exception ex)
            {
                return new ApiResult<bool> { Success = false, Error = new ApiError { Codigo = 401, MensajeError = "No está autorizado", MensajeDebug = ex.Message } };
            }

            LoginData loginData = new LoginData();
            UsuarioLogin login = loginData.GetById(loginId);

            RolData rolData = new RolData();
            List<long> rolIds = rolData.GetIdsByUsuarioId(login.UsuarioId);

            UsuarioLogueadoId = login.UsuarioId;
            FuncionData funcionData = new FuncionData();
            List<Funcion> funciones = funcionData.GetByRolesId(rolIds);

            ApiResult<bool> apiResult = new ApiResult<bool>();
            apiResult.Success = true;
            apiResult.Value = funciones.Exists(x => x.Nombre == funcion);
            return apiResult;
        }
    }
}
