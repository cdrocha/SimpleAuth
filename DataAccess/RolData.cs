using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class RolData : BaseData
    {
        public RolData()
        {
        }

        public Rol GetById(long rolId)
        {
            return _simpleAuthDBContext.Rol.Find(rolId);
        }

        public List<Rol> GetByUsuarioId(long usuarioId)
        {
            return _simpleAuthDBContext.UsuarioRol.Include(x => x.Rol).Where(x => x.UsuarioId == usuarioId).Select(x => x.Rol).ToList();
        }

        //Devuelve todos los RolesId que posee un usuario.
        public List<long> GetIdsByUsuarioId(long usuarioId)
        {
            return _simpleAuthDBContext.UsuarioRol.Where(x => x.UsuarioId == usuarioId).Select(x => x.RolId).ToList();
        }
    }
}
