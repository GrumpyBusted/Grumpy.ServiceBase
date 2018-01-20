using System.Threading;

namespace Grumpy.ServiceBase.UnitTests.Helper
{
    internal class MyCancelableService : CancelableServiceBase
    {
        public int ProcessCount;
        public bool GracefulExit;

        protected override void Process(CancellationToken cancellationToken)
        {
            ProcessCount = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                Thread.Sleep(1000);

                ++ProcessCount;
            }

            GracefulExit = true;
        }
    }
}
