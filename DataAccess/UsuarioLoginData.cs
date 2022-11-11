using DataAccess.Models;
using System.Linq;

namespace DataAccess
{
    public class UsuarioLoginData : BaseData
    {
        public UsuarioLoginData()
        {
        }

        public UsuarioLogin GetByUserName(string userName)
        {
            return _simpleAuthDBContext.UsuarioLogin.FirstOrDefault(x => x.NombreUsuario == userName);
        }
    }
}
