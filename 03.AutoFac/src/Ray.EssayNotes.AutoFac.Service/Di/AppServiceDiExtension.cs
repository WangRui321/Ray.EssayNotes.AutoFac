﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Ray.EssayNotes.AutoFac.Service.Di
{
    public static class AppServiceDiExtension
    {
        public static Autofac.ContainerBuilder AddAppServices(this Autofac.ContainerBuilder builder)
        {
            Assembly appServiceAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(appServiceAssembly)
                .Where(cc => cc.Name.EndsWith("Service"))//筛选具象类（concrete classes）
                .PublicOnly()//只要public访问权限的
                .Where(cc => cc.IsClass)//只要class型（主要为了排除值和interface类型）
                .AsImplementedInterfaces();//自动以其实现的所有接口类型暴露（包括IDisposable接口）

            return builder;
        }
    }
}
