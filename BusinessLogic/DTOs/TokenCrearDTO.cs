using System;
using System.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic.DTOs
{
    internal class TokenCrearDTO
    {
        /// <summary>
        /// Dueño del token
        /// </summary>
        public long UsuarioLoginId { get; set; }
        /// <summary>
        /// Clave que se utilizará para firmar el token. Como mínimo debe tener 16 caracteres.
        /// </summary>
        public string secretKey { get; set; }
        public string audienceToken { get; set; }
        public string issuerToken { get; set; }

        /// <summary>
        /// Cuantos minutos de vida tiene el token a ser generado.
        /// </summary>
        public int expireTimeInMinutes { get; set; }
    }
}