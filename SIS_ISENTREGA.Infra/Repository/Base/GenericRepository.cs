using SIS_ISENTREGA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace SIS_ISENTREGA.DataAccess
{
    public class GenericRepository<TEntity> : IReading<TEntity>, IRecording<TEntity>, IDisposable where TEntity : class
    {
        private readonly ConnectionClass _conn;
        public GenericRepository()
        {
            _conn = new ConnectionClass();
            //_conn = conn;
        }
        public void Add(TEntity newRegister)
        {
            _conn.Set<TEntity>().Add(newRegister);
            _conn.SaveChanges();
            Dispose();
        }

        public TEntity AddReturnEntity(TEntity newRegister)
        {
            _conn.Set<TEntity>().Add(newRegister);
            _conn.SaveChanges();
         
            return newRegister;
        }
        public void Update(TEntity registerUpdate)
        {
            _conn.Entry(registerUpdate).State = System.Data.Entity.EntityState.Modified;
            _conn.SaveChanges();
            Dispose();
        }
        public void Delete(int id)
        {
            var ent = _conn.Set<TEntity>().Find(id);
            _conn.Set<TEntity>().Remove(ent);
            _conn.SaveChanges();
         
        }

        public void DeleteEntity(TEntity entity)
        {
            _conn.Set<TEntity>().Remove(entity);
            _conn.SaveChanges();
           
        }

        public void Dispose()
        {
            _conn.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> lstResult = _conn.Set<TEntity>().AsNoTracking();
            return lstResult.ToList();
        }

        public IEnumerable<TEntity> GetAllParameters(TEntity parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetFilters(Expression<Func<TEntity, bool>> filtro)
        {

            IQueryable<TEntity> lstRegisters = _conn.Set<TEntity>().AsNoTracking().Where(filtro);
            return lstRegisters.ToList();
        }

        public Task<IEnumerable<TEntity>> GetFiltersAsync(Expression<Func<TEntity, bool>> filtro)
        {
            throw new NotImplementedException();
        }


    }
}
