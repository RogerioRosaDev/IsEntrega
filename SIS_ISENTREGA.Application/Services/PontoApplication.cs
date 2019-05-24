using AutoMapper;
using SIS_ISENTREGA.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SIS_ISENTREGA.Application
{
    public class PontoApplication : IPontoApplication
    {
        private readonly IPontoRepository _repositorio;
        public PontoApplication(IPontoRepository repositorio)
        {
            _repositorio = repositorio;
        }
        public void Add(PontoViewModel newRegister)
        {
            _repositorio.Add(Mapper.Map<PontoViewModel, Ponto>(newRegister));
        }

        public PontoViewModel AddReturnEntity(PontoViewModel newRegister)
        {
            return Mapper.Map<Ponto, PontoViewModel>(_repositorio.AddReturnEntity(Mapper.Map<PontoViewModel, Ponto>(newRegister)));
        }

        public void Delete(int id)
        {
            _repositorio.Delete(id);

        }

        public void DeleteEntity(PontoViewModel entity)
        {
            _repositorio.DeleteEntity(Mapper.Map<PontoViewModel, Ponto>(entity));
        }

        public IEnumerable<PontoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Ponto>, IEnumerable<PontoViewModel>>(_repositorio.GetAll());
        }

        public IEnumerable<PontoViewModel> GetAllParameters(PontoViewModel parameters)
        {
            return Mapper.Map<IEnumerable<Ponto>, IEnumerable<PontoViewModel>>(_repositorio.GetAllParameters(Mapper.Map<PontoViewModel, Ponto>(parameters)));
        }

        public IEnumerable<PontoViewModel> GetFilters(Expression<Func<PontoViewModel, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PontoViewModel>> GetFiltersAsync(Expression<Func<PontoViewModel, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public void Update(PontoViewModel registerUpdate)
        {
            _repositorio.Update(Mapper.Map<PontoViewModel,Ponto>(registerUpdate));
        }
    }
}
