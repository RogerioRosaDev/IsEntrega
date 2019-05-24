using Ninject.Modules;
using SIS_ISENTREGA.Application;
using SIS_ISENTREGA.Domain;
using SIS_ISENTREGA.DataAccess;
namespace SIS_ISENTREGA.IOC
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            Bind<IPontoApplication>().To<PontoApplication>();
            Bind<IPontoRepository>().To<PontoRepository>();
            Bind<IUsuarioApplication>().To<UsuarioApplication>();
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Bind<IMatrizApplication>().To<MatrizApplication>();
            Bind<IMatrizRepository>().To<MatrizRepository>();

        }
    }
}
