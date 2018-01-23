using System;
using System.Threading;
using Grumpy.Common;
using Grumpy.ServiceBase.Interfaces;

namespace Grumpy.ServiceBase
{
    /// <inheritdoc cref="ITopshelfService" />
    /// <summary>
    /// Base class for Windows Services
    /// </summary>
    /// <seealso cref="T:Grumpy.ServiceBase.CancelableServiceBase" />
    /// <seealso cref="T:Grumpy.ServiceBase.Interfaces.ITopshelfService" />
    public abstract class ServiceBase : CancelableServiceBase, ITopshelfService 
    {
        /// <summary>
        /// Service Name
        /// </summary>
        public string ServiceName { get; }
        
        /// <summary>
        /// Instance Name
        /// </summary>
        public string InstanceName { get; }

        /// <summary>
        /// Create service
        /// </summary>
        /// <param name="serviceName">Service Name</param>
        /// <param name="instanceName">Instance Name</param>
        protected ServiceBase(string serviceName = null, string instanceName = null)
        {
            ServiceName = serviceName ?? new ProcessInformation().ProcessName;
            InstanceName = instanceName;

            if (InstanceName == null)
            {
                var array = ServiceName.Split('$');

                ServiceName = array.Length == 2 ? array[0] : ServiceName;
                InstanceName = array.Length == 2 ? array[1] : "";
            }
        }

        /// <inheritdoc />
        protected abstract override void Process(CancellationToken cancellationToken);
    }
}
