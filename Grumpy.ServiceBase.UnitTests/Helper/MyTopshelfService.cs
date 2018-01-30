using System.Threading;

namespace Grumpy.ServiceBase.UnitTests.Helper
{
    public class MyTopshelfService : TopshelfServiceBase
    {
        protected override void Process(CancellationToken cancellationToken)
        {
            // Start your service
        }
    }
}