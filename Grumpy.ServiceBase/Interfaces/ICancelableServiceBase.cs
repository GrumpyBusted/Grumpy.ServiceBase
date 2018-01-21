using System;
using System.Diagnostics.CodeAnalysis;

namespace Grumpy.ServiceBase.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Base class for implementing a cancelable service
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public interface ICancelableServiceBase : IDisposable
    {
        /// <summary>
        /// Start Service
        /// </summary>
        void Start();
        
        /// <summary>
        /// Run service in this thread
        /// </summary>
        void StartSync();

        /// <summary>
        /// Stop Service
        /// </summary>
        void Stop();
    }
}