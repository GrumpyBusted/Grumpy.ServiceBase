using System.Threading;

namespace Grumpy.ServiceBase.UnitTests.Helper
{
    public class MyService : ServiceBase
    {
        /// <inheritdoc />
        public MyService(string serviceName = null, string instanceName = null) : base(serviceName, instanceName)
        {
        }

        protected override void Process(CancellationToken cancellationToken)
        {
            // Start your service
        }

        protected override void Clean()
        {
            // Clean up when services is stopped
        }
    }
}