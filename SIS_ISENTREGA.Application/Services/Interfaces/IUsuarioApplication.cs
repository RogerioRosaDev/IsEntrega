using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIS_ISENTREGA.Application
{
  public interface IUsuarioApplication
    {
        IEnumerable<UsuarioViewModel> GetAll();
        IEnumerable<UsuarioViewModel> GetAllParameters(UsuarioViewModel parameters);
        IEnumerable<UsuarioViewModel> GetFilters(Expression<Func<UsuarioViewModel, Boolean>> filtro);
        Task<IEnumerable<UsuarioViewModel>> GetFiltersAsync(Expression<Func<UsuarioViewModel, Boolean>> filtro);
        void Add(UsuarioViewModel newRegister);
        UsuarioViewModel FindLogin(string login, string senha);
        UsuarioViewModel AddReturnEntity(UsuarioViewModel newRegister);
        void Update(UsuarioViewModel registerUpdate);
        void Delete(int id);
        void DeleteEntity(UsuarioViewModel entity);
    }
}
