using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIS_ISENTREGA.Domain
{
   public interface IReading<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllParameters(TEntity parameters);
        IEnumerable<TEntity> GetFilters(Expression<Func<TEntity, Boolean>> filtro);
        Task<IEnumerable<TEntity>> GetFiltersAsync(Expression<Func<TEntity, Boolean>> filtro);
    }
}
