using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using BusinessLogic.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic.Helpers
{
    /// <summary>
    /// Todo el manejo de token es realizado por esta clase.
    /// </summary>
    internal static class TokenHelper
    {
        public static string GenerarTokenJwt(TokenCrearDTO tokenCrearDTO)
        {
            // appsetting for Token JWT

            if (tokenCrearDTO.secretKey.Length < 16)
                throw new Exception("Secret Key para generar el token debe tener al menos 16 caracteres.");

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(tokenCrearDTO.secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, tokenCrearDTO.UsuarioLoginId.ToString()) });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: tokenCrearDTO.audienceToken,
                issuer: tokenCrearDTO.issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(tokenCrearDTO.expireTimeInMinutes),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        public static long ValidarYObtenerIdentitdad(string token, TokenCrearDTO tokenCrearDTO)
        {
            //lo primero es verificar que el token es valido: no está vencido ni ha sido modificado (adulterado).
            IEnumerable<Claim> claims = ReadAndValidateTokenJwt(token, tokenCrearDTO);

            return long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value);
        }

        private static IEnumerable<Claim> ReadAndValidateTokenJwt(string token, TokenCrearDTO tokenCrearDTO)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidAudience = tokenCrearDTO.audienceToken,
                ValidIssuer = tokenCrearDTO.issuerToken,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(tokenCrearDTO.secretKey))
            };

            SecurityToken validateToken;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            if (handler.CanReadToken(token))
            {
                try
                {
                    var user = handler.ValidateToken(token, validationParameters, out validateToken);
                    
                    if(DateTime.UtcNow > validateToken.ValidTo)
                        throw new Exception("Token expirado.");

                    //Si bien los tokens generados pueden ser utilizados inmediatamente, se contempla el caso de generar tokens a futuro.
                    if (DateTime.UtcNow < validateToken.ValidFrom)
                        throw new Exception("El Token aún no puede ser utilizado.");

                    return user.Claims;
                }
                catch(SecurityTokenInvalidSignatureException)
                {
                    throw new Exception("Token inválido.");
                }
                catch (SecurityTokenExpiredException)
                {
                    throw new Exception("Token expirado.");
                }
            }

            throw new Exception("Token is invalid.");
        }

    }
}