using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SIS_ISENTREGA.Application
{
    public interface IMatrizApplication
    {
        IEnumerable<MatrizViewModel> GetAll();
        IEnumerable<MatrizViewModel> GetAllParameters(MatrizViewModel parameters);
        IEnumerable<MatrizViewModel> GetFilters(Expression<Func<MatrizViewModel, Boolean>> filtro);
        Task<IEnumerable<MatrizViewModel>> GetFiltersAsync(Expression<Func<MatrizViewModel, Boolean>> filtro);
        void Add(MatrizViewModel newRegister);
        MatrizViewModel AddReturnEntity(MatrizViewModel newRegister);
        void Update(MatrizViewModel registerUpdate);
        void Delete(int id);
        void DeleteEntity(MatrizViewModel entity);
        void DeletarCascate(int id);
    }
}
