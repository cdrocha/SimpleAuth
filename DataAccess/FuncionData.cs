using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class FuncionData : BaseData
    {
        public FuncionData()
        {
        }

        public Funcion GetById(long funcionId)
        {
            return _simpleAuthDBContext.Funcion.Find(funcionId);
        }

        public List<Funcion> GetByRolesId(List<long> rolIds)
        {
            return _simpleAuthDBContext.RolFuncion.Include(x => x.Funcion).Where(x => rolIds.Contains(x.RolId)).Select(x => x.Funcion).ToList();
        }
    }
}
