using BusinessLogic.DTOs;
using BusinessLogic.Helpers;
using DataAccess;
using DataAccess.DTOs;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace BusinessLogic
{
    /// <summary>
    /// Esta clase maneja el ingreso del usuario a la aplicación.
    /// </summary>
    public class Autenticacion
    {
        private readonly IConfiguration _config;

        public Autenticacion(IConfiguration config)
        {
            _config = config;
        }
        /// <summary>
        /// Se validan las credenciales y, en caso de login exitoso se devuelve un token
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ApiResult<string> Login(string nombreUsuario, string password)
        {
            //Primero buscamos al usuario
            UsuarioLoginData usuarioLoginData = new UsuarioLoginData();
            UsuarioLogin usuarioLogin = usuarioLoginData.GetByUserName(nombreUsuario);

            if(usuarioLogin == null)
            {
                return new ApiResult<string> { Success = false, Error = new ApiError { Codigo = 404, MensajeError = "El usuario no existe." } };
            }

            //Busco el usuario
            UsuarioData usuarioData = new UsuarioData();
            usuarioLogin.Usuario = usuarioData.GetUsuarioById(usuarioLogin.UsuarioId);
            if (!usuarioLogin.Usuario.Activo)
            {
                return new ApiResult<string> { Success = false, Error = new ApiError { Codigo = 400, MensajeError = "El usuario no puede ser utilizado." } };
            }

            if (!ValidarPassword(usuarioLogin.Password, password))
            {
                return new ApiResult<string> { Success = false, Error = new ApiError { Codigo = 400, MensajeError = "Password is invalid" } };
            }

            TokenCrearDTO tokenCrearDTO = new TokenCrearDTO();

            // appsetting for Token JWT
            
            tokenCrearDTO.UsuarioLoginId = usuarioLogin.UsuarioLoginId;
            tokenCrearDTO.secretKey = _config.GetValue<string>("TokenConfiguration:JWT_SECRET_KEY");
            tokenCrearDTO.audienceToken = _config.GetValue<string>("TokenConfiguration:JWT_AUDIENCE_TOKEN");
            tokenCrearDTO.issuerToken = _config.GetValue<string>("TokenConfiguration:JWT_ISSUER_TOKEN");
            tokenCrearDTO.expireTimeInMinutes = _config.GetValue<int>("TokenConfiguration:JWT_EXPIRE_MINUTES");

            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.Success = true;
            apiResult.Value = TokenHelper.GenerarTokenJwt(tokenCrearDTO);
            return apiResult;
        }


        private bool ValidarPassword(string passwordGuardado, string passwordRecibido, bool estaEncriptado = false)
        {
            if(!estaEncriptado)
            {
                return passwordRecibido == passwordGuardado;
            }

            return false;
        }
    }
}