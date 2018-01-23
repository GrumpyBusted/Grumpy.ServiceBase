using System;

namespace Grumpy.ServiceBase.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Base class for implementing a cancelable service
    /// </summary>
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