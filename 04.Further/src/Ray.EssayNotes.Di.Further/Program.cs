﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Ray.EssayNotes.Di.ContainerDemo.IServices;
using Ray.EssayNotes.Di.ContainerDemo.Services;
using Ray.EssayNotes.Di.Further.Test;

namespace Ray.EssayNotes.Di.Further
{
    class Program
    {
        /// <summary>
        /// 根容器
        /// </summary>
        public static IServiceProvider ServiceProviderRoot { get; set; }

        /// <summary>
        /// 持久化一个子域1，不释放
        /// </summary>
        public static IServiceScope ChildScope1 { get; set; }

        /// <summary>
        /// 持久化一个子域2，不释放
        /// </summary>
        public static IServiceScope ChildScope2 { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Program.ServiceProviderRoot = new ServiceCollection()
                .AddTransient<IMyTransientService, MyTransientService>()
                .AddSingleton<IMySingletonService, MySingletonService>()
                .AddScoped<IMyScopedService, MyScopedOtherService>()
                .AddScoped<IMyScopedService, MyScopedService>()
                .BuildServiceProvider();

            while (true)
            {
                Console.WriteLine($"\r\n请输入测试用例编号：{TestFactory.Selections.AsFormatJsonStr()}");
                string num = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(num)) continue;

                ITest test = TestFactory.Create(num);
                test.Run();
            }
        }
    }
}
