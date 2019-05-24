using SIS_ISENTREGA.Application.AutoMapper;
using System.Web.Mvc;
using System.Web.Routing;

namespace SIS_ISENTREGA.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AutoMapperConfig.RegisterMapping();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        
        }
    }
}
