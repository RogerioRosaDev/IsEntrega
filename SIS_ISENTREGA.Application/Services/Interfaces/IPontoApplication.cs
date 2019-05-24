using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SIS_ISENTREGA.Application
{
    public  interface IPontoApplication
    {
        IEnumerable<PontoViewModel> GetAll();
        IEnumerable<PontoViewModel> GetAllParameters(PontoViewModel parameters);
        IEnumerable<PontoViewModel> GetFilters(Expression<Func<PontoViewModel, Boolean>> filtro);
        Task<IEnumerable<PontoViewModel>> GetFiltersAsync(Expression<Func<PontoViewModel, Boolean>> filtro);
        void Add(PontoViewModel newRegister);
        PontoViewModel AddReturnEntity(PontoViewModel newRegister);
        void Update(PontoViewModel registerUpdate);
        void Delete(int id);
        void DeleteEntity(PontoViewModel entity);
    }
}
