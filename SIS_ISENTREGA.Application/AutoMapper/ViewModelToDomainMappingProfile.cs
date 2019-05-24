using AutoMapper;
using SIS_ISENTREGA.Domain;

namespace SIS_ISENTREGA.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<BaseViewModel, Base>();
            Mapper.CreateMap<UsuarioViewModel, Usuario > ();
            Mapper.CreateMap<MatrizViewModel, Matriz>();
            Mapper.CreateMap<PontoViewModel, Ponto>();
        }
    }
}
