using System.Linq;
using System.Reflection;
//
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//
using Ray.EssayNotes.AutoFac.Infrastructure.CoreIoc.Extensions;
using Ray.EssayNotes.AutoFac.Infrastructure.CoreIoc.Helpers;


namespace Ray.EssayNotes.AutoFac.CoreApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //注册
            //自定义注册
            //services.AddMyServices();

            services.AddMyServices();
            
            /*
            //自定义批量注册
            Assembly[] assemblies = ReflectionHelper.GetAllAssembliesCoreWeb();
            //repository
            Assembly repositoryAssemblies = assemblies.FirstOrDefault(x => x.FullName.Contains(".Repository"));
            services.AddAssemblyServices(repositoryAssemblies);
            //service
            Assembly serviceAssemblies = assemblies.FirstOrDefault(x => x.FullName.Contains(".Service"));
            services.AddAssemblyServices(serviceAssemblies);
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production
                // scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}