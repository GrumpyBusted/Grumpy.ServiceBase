using System;
using System.Diagnostics.CodeAnalysis;
using Grumpy.Common;
using Grumpy.Common.Extensions;
using Grumpy.ServiceBase.Interfaces;
using Topshelf;
using Topshelf.HostConfigurators;

namespace Grumpy.ServiceBase
{
    public static class TopshelfUtility
    {
        [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
        public static Action<HostConfigurator> BuildService<T>(Func<string, T> serviceBuilder) where T : class, ITopshelfService
        {
            var assemblyInfo = new AssemblyInformation();

            return x =>
            {
                x.Service<T>(s =>
                {
                    s.ConstructUsing(serviceBuilder);
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription(assemblyInfo.Description);
                x.SetDisplayName(assemblyInfo.Title + (assemblyInfo.Version.NullOrEmpty() ? "" : $" (Version: {assemblyInfo.Version})"));
                x.SetServiceName(assemblyInfo.Title);
            };
        }

        [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
        public static Action<HostConfigurator> BuildService<T>(Func<T> serviceBuilder) where T : class, ITopshelfService
        {
            var assemblyInfo = new AssemblyInformation();

            return x =>
            {
                x.Service<T>(s =>
                {
                    s.ConstructUsing(serviceBuilder);
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription(assemblyInfo.Description);
                x.SetDisplayName(assemblyInfo.Title + (assemblyInfo.Version.NullOrEmpty() ? "" : $" (Version: {assemblyInfo.Version})"));
                x.SetServiceName(assemblyInfo.Title);
            };
        }
    }
}
