using SIS_ISENTREGA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace SIS_ISENTREGA.Application
{
    public  class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository _repositorio;
        public UsuarioApplication(IUsuarioRepository repositorio)
        {
            _repositorio = repositorio;
        }
        public void Add(UsuarioViewModel newRegister)
        {
            _repositorio.Add(Mapper.Map<UsuarioViewModel,Usuario>(newRegister));
        }

        public UsuarioViewModel AddReturnEntity(UsuarioViewModel newRegister)
        {
           return Mapper.Map<Usuario, UsuarioViewModel>(  _repositorio.AddReturnEntity(Mapper.Map<UsuarioViewModel, Usuario>(newRegister)));
        }

        public void Delete(int id)
        {
            _repositorio.Delete(id);
        }

        public void DeleteEntity(UsuarioViewModel entity)
        {
            _repositorio.DeleteEntity(Mapper.Map<UsuarioViewModel, Usuario>(entity));
        }

        public UsuarioViewModel FindLogin(string login, string senha)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_repositorio.FindLogin(login, senha));
        }

        public IEnumerable<UsuarioViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Usuario>,IEnumerable<UsuarioViewModel>>(_repositorio.GetAll());
        }

        public IEnumerable<UsuarioViewModel> GetAllParameters(UsuarioViewModel parameters)
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_repositorio.GetAllParameters(Mapper.Map<UsuarioViewModel, Usuario>(parameters)));
        }

        public IEnumerable<UsuarioViewModel> GetFilters(Expression<Func<UsuarioViewModel, bool>> filtro)
        {
            throw new NotImplementedException();
            //return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_repositorio.GetFilters(Mapper.Map<UsuarioViewModel, Usuario>(filtro)));
        }

        public Task<IEnumerable<UsuarioViewModel>> GetFiltersAsync(Expression<Func<UsuarioViewModel, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public void Update(UsuarioViewModel registerUpdate)
        {
            _repositorio.Update(Mapper.Map<UsuarioViewModel, Usuario>(registerUpdate));
        }
    }
}
