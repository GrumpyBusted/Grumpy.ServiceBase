using FluentAssertions;
using Grumpy.ServiceBase.UnitTests.Helper;
using Xunit;

namespace Grumpy.ServiceBase.UnitTests
{
    public class ServiceBaseTests
    {
        [Fact]
        public void CanCreate()
        {
            var cut = new MyService();

            cut.Start();
            cut.Stop();
        }

        [Fact]
        public void CanSetServiceName()
        {
            var cut = new MyService("MyService");

            cut.ServiceName.Should().Be("MyService");
        }

        [Fact]
        public void WillDefaultServiceName()
        {
            var cut = new MyService();

            cut.ServiceName.Should().NotBeEmpty();
        }

        [Fact]
        public void CanSetInstanceName()
        {
            var cut = new MyService("MyService", "1");

            cut.InstanceName.Should().Be("1");
        }

        [Fact]
        public void CanSetUsingTopshelfNotation()
        {
            var cut = new MyService("MyService$1");

            cut.ServiceName.Should().Be("MyService");
            cut.InstanceName.Should().Be("1");
        }
    }
}