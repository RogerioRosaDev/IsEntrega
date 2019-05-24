using AutoMapper;
using SIS_ISENTREGA.Domain;

namespace SIS_ISENTREGA.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappingProfile"; }

        }
        protected override void Configure()
        {
            Mapper.CreateMap<Base, BaseViewModel>();
            Mapper.CreateMap<Usuario,UsuarioViewModel>();
            Mapper.CreateMap<Matriz, MatrizViewModel>();
            Mapper.CreateMap<Ponto, PontoViewModel>();
        }
    }
}
