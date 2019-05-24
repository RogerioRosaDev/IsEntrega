using SIS_ISENTREGA.Domain;
using System.Linq;

namespace SIS_ISENTREGA.DataAccess
{
    public class MatrizRepository : GenericRepository<Matriz>, IMatrizRepository
    {
        private readonly IPontoRepository _ponto;
       // private readonly IMatrizRepository _matriz;
        public MatrizRepository(IPontoRepository ponto)
        {
            _ponto = ponto;
            //_matriz = matriz;
        }
        public void DeletarCascate(int id)
        {
            using (var conn = new ConnectionClass())
            {
                IQueryable<Ponto> lstResult = conn.Set<Ponto>().AsNoTracking();

                var lst = lstResult.Where(r => r.OidMatriz == id).ToList();
                if (lst.Count > 0)
                {
                    lst.ToList().ForEach(r => {

                        var pont = conn.Ponto.FirstOrDefault(x => x.OidPonto == r.OidPonto);
                        conn.Ponto.Remove(pont);
                    });
                    var _mat = conn.Matriz.FirstOrDefault(r => r.OidMatriz == id);
                    conn.Matriz.Remove(_mat);
                    conn.SaveChanges();
                }
                else
                {
                    var _mat = conn.Set<Matriz>().FirstOrDefault(r => r.OidMatriz == id);
                    conn.Set<Matriz>().Remove(_mat);
                    conn.SaveChanges();
                }
                
            }
        }
    }
}
