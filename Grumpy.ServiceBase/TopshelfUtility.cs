﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Grumpy.Common;
using Grumpy.Common.Extensions;
using Grumpy.ServiceBase.Interfaces;
using Topshelf;
using Topshelf.HostConfigurators;

namespace Grumpy.ServiceBase
{
    /// <summary>
    /// Utility class to be able to start service in one line of main
    /// </summary>
    public static class TopshelfUtility
    {
        /// <summary>
        /// Build a Topshelf Service
        /// </summary>
        /// <param name="serviceBuilder"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
        public static Action<HostConfigurator> BuildService<T>(Func<string, T> serviceBuilder) where T : class, ITopshelfService
        {
            var assemblyInfo = new AssemblyInformation(Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly());

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
            };
        }

        /// <summary>
        /// Build a Topshelf Service
        /// </summary>
        /// <param name="serviceBuilder"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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
