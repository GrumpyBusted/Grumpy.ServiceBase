using System.Threading;

namespace Grumpy.ServiceBase.UnitTests.Helper
{
    internal class MyFastCancelableService : CancelableServiceBase
    {
        protected override void Process(CancellationToken cancellationToken)
        {
        }
    }
}
