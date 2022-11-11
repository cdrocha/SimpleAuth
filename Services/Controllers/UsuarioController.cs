using BusinessLogic;
using DataAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAuth.Controllers
{
    [Route("usuarios")]
    public class UsuarioController : AuthController
    {
        private readonly UsuarioBO _usuarioBO;

        public UsuarioController(UsuarioBO usuarioBO, Autenticacion autenticacion, Autorizacion autorizacion) : base(autenticacion, autorizacion)
        {
            _usuarioBO = usuarioBO;
        }

        // POST: UsuarioController/Crear
        [HttpPost]
        public ActionResult<ApiResult<long>> Crear([FromBody] UsuarioCrear usuarioCrear)
        {
            try
            {
                //primero valido
                var autorizado = Autorizar("UsuarioCrear");
                if (autorizado.Value == null)
                {
                    return autorizado.Result;
                }

                //si tiene permiso, ejecuto la accion
                UsuarioBO usuarioBO = new UsuarioBO();
                return usuarioBO.CrearUsuarioYLogin(UsuarioLogueadoId, usuarioCrear);
            }
            catch(System.Exception ex)
            {
                return new BadRequestResult();
            }
        }

        // POST: UsuarioController/Crear
        [HttpPost("{usuarioId}/roles/{rolId}")]
        public ActionResult<ApiResult<long>> AsociarRol([FromRoute] long usuarioId, [FromRoute] long rolId)
        {
            try
            {
                UsuarioRolCrear usuarioRolCrear = new UsuarioRolCrear { RolId = rolId, UsuarioId = usuarioId };

                //primero valido
                var autorizado = Autorizar("UsuarioAsociarRol");
                if (autorizado.Value == null)
                {
                    return autorizado.Result;
                }

                //si tiene permiso, ejecuto la accion
                UsuarioBO usuarioBO = new UsuarioBO();
                return usuarioBO.AgregarRol(UsuarioLogueadoId, usuarioRolCrear);
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        // GET: UsuarioController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UsuarioController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UsuarioController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UsuarioController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
