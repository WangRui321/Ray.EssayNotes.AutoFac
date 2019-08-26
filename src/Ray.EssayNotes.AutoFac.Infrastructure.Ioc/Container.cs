using Autofac;
using Autofac.Core;
using Ray.EssayNotes.AutoFac.Repository.IRepository;
using Ray.EssayNotes.AutoFac.Repository.Repository;
using Ray.EssayNotes.AutoFac.Service.IService;
using Ray.EssayNotes.AutoFac.Service.Service;
using System;
using System.Reflection;

namespace Ray.EssayNotes.AutoFac.Infrastructure.Ioc
{
    /// <summary>
    /// 控制台程序容器
    /// </summary>
    public static class Container
    {
        /// <summary>
        /// 容器
        /// </summary>
        public static IContainer Instance;

        /// <summary>
        /// 初始化容器
        /// </summary>
        /// <param name="func">委托</param>
        /// <returns></returns>
        public static void Init(Func<ContainerBuilder, ContainerBuilder> func = null)
        {
            //新建容器构建器，用于注册组件和服务
            var builder = new ContainerBuilder();
            //注册组件
            MyBuild(builder);
            func?.Invoke(builder);
            //利用构建器创建容器
            Instance = builder.Build();
        }

        /// <summary>
        /// 自定义注册
        /// </summary>
        /// <param name="builder"></param>
        public static void MyBuild(ContainerBuilder builder)
        {
            //BuildContainerFunc1(builder);
            //BuildContainerFunc2(builder);
            //BuildContainerFunc3(builder);
            //BuildContainerFunc4(builder);
            //BuildContainerFunc5(builder);
            //BuildContainerFunc6(builder);
            BuildContainerFunc8(builder);
        }

        #region 几种注册特性

        /// <summary>
        /// 方法1：指定类型（type）暴露接口（interface）
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildContainerFunc1(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType(typeof(StudentService)).As(typeof(IStudentService));
        }

        /// <summary>
        /// 方法2：自己创建实例注册
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildContainerFunc2(ContainerBuilder builder)
        {
            var stuRepository = new StudentRepository();
            var stuService = new StudentService(stuRepository);
            builder.RegisterInstance(stuService).As<IStudentService>();
            builder.RegisterInstance(stuRepository).As<IStudentRepository>();
            //利用ExternallyOwned()函数接管容器的生命周期控制权
            //builder.RegisterInstance(stuRepository).As<IStudentRepository>()
            //    .ExternallyOwned();
        }

        /// <summary>
        /// 方法3：拉姆达表达式创建实体，实现注册
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildContainerFunc3(ContainerBuilder builder)
        {
            builder.Register(x => new StudentRepository())
                .As<IStudentRepository>();
            builder.Register(x => new StudentService(x.Resolve<IStudentRepository>()))
                .As<IStudentService>();
        }

        /// <summary>
        /// 方法4：指定类型（type）
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildContainerFunc4(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>();
            builder.RegisterType<StudentRepository>();
            //builder.RegisterType(typeof(StudentService));
            //builder.RegisterType(typeof(StudentRepository));
            //还可以自己指定构造函数
            //builder.RegisterType<StudentRepository>()
            //    .UsingConstructor(typeof(StudentRepository));
        }

        /// <summary>
        /// 方法5：属性注入
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildContainerFunc5(ContainerBuilder builder)
        {
            //builder.RegisterType<TeacherRepository>().As<ITeacherRepository>();
            builder.Register(x => new TeacherService { TeacherRepository = x.ResolveOptional<ITeacherRepository>() })
                .As<ITeacherService>();

            builder.RegisterType<TeacherService>().PropertiesAutowired();
        }

        /// <summary>
        /// 方法6：泛型注入
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildContainerFunc6(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>))
                .As(typeof(IBaseRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<BookService>()
                .As<IBookService>();
        }

        /// <summary>
        /// 方法7：已注册内容进行判断
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildContainerFunc7(ContainerBuilder builder)
        {
            builder.RegisterType<TeacherRepository>()
                .As<ITeacherRepository>()
                .IfNotRegistered(typeof(ITeacherRepository));

            builder.RegisterType<TeacherRepository>()
                .AsSelf()
                .IfNotRegistered(typeof(ITeacherRepository));

            builder.RegisterType<TeacherService>()
                .AsSelf()
                .As<ITeacherService>()
                .OnlyIf(x =>
                    x.IsRegistered(new TypedService(typeof(ITeacherRepository))) ||
                    x.IsRegistered(new TypedService(typeof(TeacherRepository))));
        }

        /// <summary>
        /// 方法8：通过反射程序集
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildContainerFunc8(ContainerBuilder builder)
        {
            Assembly[] assemblies = Helpers.ReflectionHelper.GetAllAssemblies();

            builder.RegisterAssemblyTypes(assemblies)//程序集内所有具象类（concrete classes）
                .Where(cc => cc.Name.EndsWith("Repository") |//筛选
                            cc.Name.EndsWith("Service"))
                .PublicOnly()//只要public访问权限的
                .Where(cc => cc.IsClass)//只要class型（主要为了排除值和interface类型）
                                        //.Except<TeacherRepository>()//排除某类型
                                        //.As(x=>x.GetInterfaces()[0])//反射出其实现的接口，默认以第一个接口类型暴露
                .AsImplementedInterfaces();//自动以其实现的所有接口类型暴露（包括IDisposable接口）

            builder.RegisterGeneric(typeof(BaseRepository<>))
                .As(typeof(IBaseRepository<>));
        }

        /// <summary>
        /// 暴露类型
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildContainerFunc9(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>();
            builder.RegisterType<StudentService>().AsSelf();
            builder.RegisterType<StudentService>().As<StudentService>();
            builder.RegisterType<StudentService>().As(typeof(StudentService));
        }
        #endregion
    }
}