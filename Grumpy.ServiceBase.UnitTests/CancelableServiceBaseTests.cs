using System.Diagnostics;
using System.Threading;
using FluentAssertions;
using Grumpy.ServiceBase.Interfaces;
using Grumpy.ServiceBase.UnitTests.Helper;
using Xunit;

namespace Grumpy.ServiceBase.UnitTests
{
    public class CancelableServiceBaseTests
    {
        [Fact]
        public void StopGracefully()
        {
            var cut = new MyCancelableService();
            cut.Start();
            Thread.Sleep(200);
            cut.Stop();
            cut.GracefulExit.Should().BeTrue();
        }

        [Fact]
        public void OneProcessCountPerSecond()
        {
            var cut = new MyCancelableService();
            Thread.Sleep(200);
            cut.Start();
            Thread.Sleep(2500);
            cut.Stop();
            cut.ProcessCount.Should().BeGreaterOrEqualTo(2);
        }

        [Fact]
        public void WaitForSleep()
        {
            var cut = new MyCancelableService();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            cut.Start();
            Thread.Sleep(200);
            cut.Stop();
            stopWatch.Stop();
            stopWatch.ElapsedMilliseconds.Should().BeGreaterOrEqualTo(900);
        }

        [Fact]
        public void CanBeDispose()
        {
            using (var cut = CreateCut())
            {
                cut.Start();
            }
        }

        [Fact]
        public void CanStartSync()
        {
            using (var cut = (ICancelableServiceBase)new MyFastCancelableService())
            {
                cut.StartSync();
            }
        }

        [Fact]
        public void CanStartSyncWithCancellation()
        {
            using (var cut = (ICancelableServiceBase)new MyFastCancelableService())
            {
                cut.StartSync(new CancellationToken());
            }
        }

        [Fact]
        public void CanStartWithCancellation()
        {
            using (var cut = (ICancelableServiceBase)new MyFastCancelableService())
            {
                cut.Start(new CancellationToken());
            }
        }

        private static ICancelableServiceBase CreateCut()
        {
            return new MyCancelableService();
        }
    }
}
