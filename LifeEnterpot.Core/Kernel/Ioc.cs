using System;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Threading.Tasks;
using LifeEnterpot.Core;
using Autofac;
using LifeEnterpot.Core.Providers;


namespace LifeEnterpot.Core.Kernel
{ 
    public class Ioc
    {
        private static IContainer container;

        public static void Register(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AppLayoutProvider>()
            .As<IAppLayoutProvider>()
            .SingleInstance();

        }

        public static void Register(ContainerBuilder builder)
        {
            container = builder.Build();
        }
        public static T Get<T>() where T : class
        {
            if (typeof(T).IsInterface == false)
            {
                throw new Exception("T must be interface");
            }
            return container.Resolve<T>();
        }

        public static T Get<T>(string name) where T : class
        {
            if (typeof(T).IsInterface == false)
            {
                throw new Exception("T must be interface");
            }
            return container.ResolveNamed<T>(name);
        }
    }   
}
