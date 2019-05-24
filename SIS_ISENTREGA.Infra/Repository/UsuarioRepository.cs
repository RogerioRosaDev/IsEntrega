using SIS_ISENTREGA.Domain;
using System.Linq;

namespace SIS_ISENTREGA.DataAccess
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        //private readonly ConnectionClass _conexao;


        public Usuario FindLogin(string login, string senha)
        {
            using (var _conexao = new ConnectionClass())
            {
                IQueryable<Usuario> user = _conexao.Usuario.AsNoTracking().Where(r => r.Email == login && r.Senha == senha);
                return user.FirstOrDefault();
            }
        }
    }
}
