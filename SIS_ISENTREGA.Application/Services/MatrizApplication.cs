using SIS_ISENTREGA.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
namespace SIS_ISENTREGA.Application
{
    public class MatrizApplication : IMatrizApplication
    {
        private readonly IMatrizRepository _repo;
        public MatrizApplication(IMatrizRepository repo)
        {
            _repo =repo;
        }
        public void Add(MatrizViewModel newRegister)
        {
            _repo.Add(Mapper.Map<MatrizViewModel, Matriz>(newRegister));
        }

        public MatrizViewModel AddReturnEntity(MatrizViewModel newRegister)
        {
          return Mapper.Map<Matriz,MatrizViewModel>( _repo.AddReturnEntity(Mapper.Map<MatrizViewModel, Matriz>(newRegister)));
        }

        public void DeletarCascate(int id)
        {
            _repo.DeletarCascate(id);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public void DeleteEntity(MatrizViewModel entity)
        {
            _repo.DeleteEntity(Mapper.Map<MatrizViewModel, Matriz>(entity));
        }

        public IEnumerable<MatrizViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Matriz>, IEnumerable<MatrizViewModel>>(_repo.GetAll());
        }

        public IEnumerable<MatrizViewModel> GetAllParameters(MatrizViewModel parameters)
        {
            return Mapper.Map<IEnumerable<Matriz>, IEnumerable<MatrizViewModel>>(_repo.GetAllParameters(Mapper.Map<MatrizViewModel, Matriz>(parameters)));
        }

        public IEnumerable<MatrizViewModel> GetFilters(Expression<Func<MatrizViewModel, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MatrizViewModel>> GetFiltersAsync(Expression<Func<MatrizViewModel, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public void Update(MatrizViewModel registerUpdate)
        {
            _repo.Update(Mapper.Map<MatrizViewModel, Matriz>(registerUpdate));
        }
    }
}
