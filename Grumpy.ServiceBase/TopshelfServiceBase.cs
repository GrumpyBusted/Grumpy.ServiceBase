using System.Threading;
using Grumpy.ServiceBase.Interfaces;
using Topshelf.Runtime;

namespace Grumpy.ServiceBase
{
    /// <inheritdoc cref="ITopshelfServiceBase" />
    public abstract class TopshelfServiceBase : CancelableServiceBase, ITopshelfServiceBase
    {
        /// <inheritdoc />
        public string ServiceName { get; private set; }

        /// <inheritdoc />
        public string InstanceName { get; private set; }

        /// <inheritdoc />
        protected abstract override void Process(CancellationToken cancellationToken);

        /// <inheritdoc />
        public HostSettings HostSettings
        {
            set
            {
                Name = value.Name;
                ServiceName = value.ServiceName;
                InstanceName = value.InstanceName;
            }
        }
    }
}
