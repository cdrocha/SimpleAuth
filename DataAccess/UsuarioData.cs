using DataAccess.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class UsuarioData : BaseData
    {
        public UsuarioData()
        {
        }

        public Usuario GetUsuarioById(long usuarioId)
        {
            return _simpleAuthDBContext.Usuario.Find(usuarioId);
        }

        /// <summary>
        /// Crea un usuario con su primer login.
        /// </summary>
        /// <param name="usuarioCrear"></param>
        /// <returns></returns>
        public ApiResult<Usuario> Crear(long usuarioAltaId, UsuarioCrear usuarioCrear)
        {
            ApiResult<Usuario> apiResult = validarPassword(usuarioCrear?.UsuarioLoginCrear?.Password);
            
            if (!apiResult.Success)
            {
                return apiResult;
            }

            Usuario usuario = new Usuario();
            usuario.Activo = true;
            usuario.Apellido = usuarioCrear.Apellido;
            usuario.Email = usuarioCrear.Email;
            usuario.UsuarioAltaId = usuarioAltaId;
            usuario.FechaAlta = DateTime.Now;
            usuario.Nombre = usuarioCrear.Nombre;
            usuario.Perfil = usuarioCrear.Perfil;
            usuario.Telefono = usuarioCrear.Telefono;

            UsuarioLogin usuarioLogin = new UsuarioLogin();
            usuarioLogin.FechaAlta = DateTime.Now;
            usuarioLogin.UsuarioAltaId = usuarioAltaId;
            usuarioLogin.NombreUsuario = usuarioCrear.UsuarioLoginCrear.NombreUsuario;
            usuarioLogin.Password = usuarioCrear.UsuarioLoginCrear.Password;
            usuarioLogin.Proveedor = usuarioCrear.UsuarioLoginCrear.Proveedor;

            ApiResult<Usuario> resultadoValidacion = validarCreacionUsuario(usuarioCrear);

            if (!resultadoValidacion.Success)
                return resultadoValidacion;

            var usuarioCreado = _simpleAuthDBContext.Usuario.Add(usuario).Entity;
            _simpleAuthDBContext.SaveChanges();
            //insertar el login ahora
            usuarioLogin.UsuarioId = usuarioCreado.UsuarioId;
            UsuarioLogin loginCreado = _simpleAuthDBContext.UsuarioLogin.Add(usuarioLogin).Entity;
            _simpleAuthDBContext.SaveChanges();
            usuario.UsuarioLogin = new List<UsuarioLogin> { loginCreado };
            return new ApiResult<Usuario> { Success = true, Value = usuario };
        }

        /// <summary>
        /// Se agrega el Rol al usuario
        /// </summary>
        /// <param name="usuarioCrear"></param>
        /// <returns></returns>
        public ApiResult<UsuarioRol> AgregarRol(long usuarioAltaId, UsuarioRolCrear usuarioRolCrear)
        {
            UsuarioRol usuarioRol = new UsuarioRol();
            usuarioRol.Activo = true;
            usuarioRol.RolId = usuarioRolCrear.RolId;
            usuarioRol.UsuarioId = usuarioRolCrear.UsuarioId;
            usuarioRol.UsuarioAltaId = usuarioAltaId;
            usuarioRol.FechaAlta = DateTime.Now;

            try
            {
                ApiResult<UsuarioRol> resultadoValidacion = validarAgregarRol(usuarioRolCrear);

                if (!resultadoValidacion.Success)
                    return resultadoValidacion;

                UsuarioRol usuarioRolCreado = _simpleAuthDBContext.UsuarioRol.Add(usuarioRol).Entity;
                _simpleAuthDBContext.SaveChanges();
                return new ApiResult<UsuarioRol> { Success = true, Value = usuarioRolCreado };
            }
            catch (System.Exception ex)
            {
                return new ApiResult<UsuarioRol> { Success = false, Error = new ApiError { Codigo = 500, MensajeError = "No se puede asociar el rol al usuario", MensajeDebug = ex.Message } };
            }
        }

        private static ApiResult<Usuario> validarPassword(string password)
        {
            if (password == null || password.Length < 8)
            {
                return new ApiResult<Usuario> { Success = false, Error = new ApiError { Codigo = 400, MensajeError = "La contraseña debe tener al menos 8 caracteres." } };
            }
            bool incluyeMayusculas = false;
            bool incluyeMinuculas = false;
            bool incluyeSimbolos = false;
            bool incluyeNumeros = false;

            List<char> simbolosPermitidos = new List<char> { '@', '#', '$', '%', '^', '&', '+', '=' }; // or whatever   

            foreach (char c in password)
            {
                if (c >= 'a' && c <= 'z')
                {
                    incluyeMinuculas = true;
                }

                if (c >= 'A' && c <= 'Z')
                {
                    incluyeMayusculas = true;
                }

                if (c >= '0' && c <= '9')
                {
                    incluyeNumeros = true;
                }

                if (simbolosPermitidos.Contains(c))
                {
                    incluyeSimbolos = true;
                }
            }

            if (incluyeMayusculas && incluyeMinuculas && incluyeSimbolos && incluyeNumeros)
            {
                return new ApiResult<Usuario> { Success = true };
            }

            return new ApiResult<Usuario> { Success = false, Error = new ApiError { Codigo = 400, MensajeError = "La contraseña debe tener al menos una mayúscula, una minúscula, un numero y un simbolo." } };
        }

        private ApiResult<Usuario> validarCreacionUsuario(UsuarioCrear usuarioCrear)
        {
            var usuarioEncontrado = _simpleAuthDBContext.Usuario.FirstOrDefault(u => u.Email == usuarioCrear.Email || u.Telefono == usuarioCrear.Telefono);

            if (usuarioEncontrado != null)
            {
                return new ApiResult<Usuario> { Success = false, Error = new ApiError { Codigo = 400, MensajeError = "Ya existe un usuario para ese email o teléfono" } };
            }

            var loginEncontrado = _simpleAuthDBContext.UsuarioLogin.FirstOrDefault(u => u.NombreUsuario == usuarioCrear.UsuarioLoginCrear.NombreUsuario);

            if (loginEncontrado != null)
            {
                return new ApiResult<Usuario> { Success = false, Error = new ApiError { Codigo = 400, MensajeError = "El nombre de usuario ya está utilizado." } };
            }

            return new ApiResult<Usuario>
            {
                Success = true
            };
        }

        private ApiResult<UsuarioRol> validarAgregarRol(UsuarioRolCrear usuarioRolCrear)
        {
            var usuarioRolEncontrado = _simpleAuthDBContext.UsuarioRol.FirstOrDefault(u => u.RolId == usuarioRolCrear.RolId && u.UsuarioId == usuarioRolCrear.UsuarioId);

            if (usuarioRolEncontrado != null)
            {
                return new ApiResult<UsuarioRol> { Success = false, Error = new ApiError { Codigo = 400, MensajeError = "El Usuario ya posee ese rol." } };
            }

            return new ApiResult<UsuarioRol>
            {
                Success = true
            };
        }


    }
}
