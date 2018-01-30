using System;
using Microsoft.Extensions.Logging;

namespace Grumpy.ServiceBase.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Base class for implementing a service
    /// </summary>
    public interface IServiceBase : IDisposable
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// State of the Service
        /// </summary>
        bool Started { get; set; }

        /// <summary>
        /// Logger
        /// </summary>
        ILogger Logger { get; set; }

        /// <summary>
        /// Start Service
        /// </summary>
        void Start();

        /// <summary>
        /// Stop Service
        /// </summary>
        void Stop();
    }
}