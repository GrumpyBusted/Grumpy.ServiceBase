using FluentAssertions;
using Grumpy.ServiceBase.Interfaces;
using Grumpy.ServiceBase.UnitTests.Helper;
using Topshelf.Runtime.Windows;
using Xunit;

namespace Grumpy.ServiceBase.UnitTests
{
    public class TopshelfServiceBaseTests
    {
        [Fact]
        public void CanStartAndStop()
        {
            var cut = new MyTopshelfService();
            cut.Start();
            cut.Stop();
        }

        [Fact]
        public void CanSetServiceName()
        {
            var  cut = CreateService();

            cut.Set(new WindowsHostSettings("MyService", "1"));

            cut.ServiceName.Should().Be("MyService");
            cut.InstanceName.Should().Be("1");
        }

        private static ITopshelfServiceBase CreateService()
        {
            return new MyTopshelfService();
        }
    }
}