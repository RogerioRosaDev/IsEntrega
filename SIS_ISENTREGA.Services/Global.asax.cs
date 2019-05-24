using SIS_ISENTREGA.Application.AutoMapper;
using System.Web.Http;

namespace SIS_ISENTREGA.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
           AutoMapperConfig.RegisterMapping();
        }
    }
}
