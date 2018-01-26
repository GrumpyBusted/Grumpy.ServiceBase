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
        public string Name { get; private set; }

        /// <inheritdoc />
        protected abstract override void Process(CancellationToken cancellationToken);

        /// <inheritdoc />
        public void Set(HostSettings hostSettings)
        {
            Name = hostSettings.Name;
            ServiceName = hostSettings.ServiceName;
            InstanceName = hostSettings.InstanceName;
        }
    }
}
