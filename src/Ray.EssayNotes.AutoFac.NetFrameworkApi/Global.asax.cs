using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//
using Ray.EssayNotes.AutoFac.Infrastructure.Ioc;


namespace Ray.EssayNotes.AutoFac.NetFrameworkApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //初始化容器，并返回适用于WebApi的AutoFac解析器
            System.Web.Http.Dependencies.IDependencyResolver autoFacResolver = ApiContainer.Init();
            //获取HttpConfiguration
            HttpConfiguration config = GlobalConfiguration.Configuration;
            //将AutoFac解析器设置为系统DI解析器
            config.DependencyResolver = autoFacResolver;
        }
    }
}