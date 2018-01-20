using System.Threading;

namespace Grumpy.ServiceBase.UnitTests.Helper
{
    public class MyService : ServiceBase
    {
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