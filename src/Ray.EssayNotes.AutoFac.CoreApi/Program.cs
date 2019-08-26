using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Ray.EssayNotes.AutoFac.Infrastructure.CoreIoc.Extensions;

namespace Ray.EssayNotes.AutoFac.CoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //第一种：使用自带DI
                //.UseStartup<Startup>();

                //第二种：添加AutoFac作为辅助容器
                //.HookAutoFacIntoPipeline()
                //.UseStartup<StartupWithAutoFac>();

                //第三种：添加AutoFac接管依赖注入
                .UseStartup<StartupOnlyAutoFac>();
    }
}