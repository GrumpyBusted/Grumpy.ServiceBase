using System;
using System.Reflection;
using Grumpy.Common;
using Grumpy.Common.Extensions;
using Grumpy.ServiceBase.Interfaces;
using Topshelf;
using Topshelf.HostConfigurators;
using Topshelf.Runtime;

namespace Grumpy.ServiceBase
{
    /// <summary>
    /// Utility class to be able to start service in one line of main
    /// </summary>
    public static class TopshelfUtility
    {
        /// <summary>
        /// Run Topshelf Service
        /// </summary>
        /// <typeparam name="T">Type of Service</typeparam>
        public static void Run<T>() where T : class, ITopshelfServiceBase, new()
        {
            HostFactory.Run(BuildService(Build<T>));
        }

        /// <summary>
        /// Build Service
        /// </summary>
        /// <param name="serviceBuilder">Service Builder</param>
        /// <typeparam name="T">Type of Service</typeparam>
        /// <returns>Service Action</returns>
        private static Action<HostConfigurator> BuildService<T>(Func<HostSettings, T> serviceBuilder) where T : class, ITopshelfServiceBase
        {
            var assemblyInfo = new AssemblyInformation(Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly());

            return x =>
            {
                x.SetServiceName(assemblyInfo.Title);
                x.SetDescription(assemblyInfo.Description);
                x.SetDisplayName(assemblyInfo.Title + (assemblyInfo.Version.NullOrEmpty() ? "" : $" (Version: {assemblyInfo.Version})"));
                x.Service<T>(s =>
                {
                    s.ConstructUsing(settings => serviceBuilder(settings));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
            };
        }

        /// <summary>
        /// Service Builder
        /// </summary>
        /// <param name="hostSettings">Topshelf Host Settings</param>
        /// <typeparam name="T">Type of Service</typeparam>
        /// <returns>The Service</returns>
        private static T Build<T>(HostSettings hostSettings) where T : class, ITopshelfServiceBase, new()
        {
            var serviceClass = new T { HostSettings = hostSettings };

            return serviceClass;
        }
    }
}
