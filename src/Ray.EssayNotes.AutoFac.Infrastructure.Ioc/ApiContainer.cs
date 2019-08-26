using Autofac;
using Autofac.Integration.WebApi;
using Ray.EssayNotes.AutoFac.Repository.IRepository;
using Ray.EssayNotes.AutoFac.Repository.Repository;
using System;
using System.Linq;
using System.Reflection;

namespace Ray.EssayNotes.AutoFac.Infrastructure.Ioc
{
    /// <summary>
    /// .NET Framework WebApi容器
    /// </summary>
    public static class ApiContainer
    {
        public static IContainer Instance;

        /// <summary>
        /// 初始化Api容器
        /// </summary>
        /// <param name="func"></param>
        public static System.Web.Http.Dependencies.IDependencyResolver Init(Func<ContainerBuilder, ContainerBuilder> func = null)
        {
            //新建容器构建器，用于注册组件和服务
            var builder = new ContainerBuilder();
            //注册组件
            MyBuild(builder);
            func?.Invoke(builder);
            //利用构建器创建容器
            Instance = builder.Build();

            //返回针对WebApi的AutoFac解析器
            return new AutofacWebApiDependencyResolver(Instance);
        }

        public static void MyBuild(ContainerBuilder builder)
        {
            var assemblies = Helpers.ReflectionHelper.GetAllAssembliesWeb();

            //注册仓储 && Service
            builder.RegisterAssemblyTypes(assemblies)//程序集内所有具象类（concrete classes）
                .Where(cc => cc.Name.EndsWith("Repository") |//筛选
                             cc.Name.EndsWith("Service"))
                .PublicOnly()//只要public访问权限的
                .Where(cc => cc.IsClass)//只要class型（主要为了排除值和interface类型）
                .AsImplementedInterfaces();//自动以其实现的所有接口类型暴露（包括IDisposable接口）

            //注册泛型仓储
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>));

            //注册ApiController
            //方法1：自己根据反射注册
            //Assembly[] controllerAssemblies = assemblies.Where(x => x.FullName.Contains(".NetFrameworkApi")).ToArray();
            //builder.RegisterAssemblyTypes(controllerAssemblies)
            //    .Where(cc => cc.Name.EndsWith("Controller"))
            //    .AsSelf();
            //方法2：用AutoFac提供的专门用于注册ApiController的扩展方法
            Assembly mvcAssembly = assemblies.FirstOrDefault(x => x.FullName.Contains(".NetFrameworkApi"));
            builder.RegisterApiControllers(mvcAssembly);
        }
    }
}