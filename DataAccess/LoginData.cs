using DataAccess.Models;

namespace DataAccess
{
    public class LoginData : BaseData
    {
        public LoginData()
        {
        }

        public UsuarioLogin GetById(long usuarioLoginId)
        {
            return _simpleAuthDBContext.UsuarioLogin.Find(usuarioLoginId);
        }
    }
}
