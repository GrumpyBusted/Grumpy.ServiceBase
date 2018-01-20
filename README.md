[![Build status](https://ci.appveyor.com/api/projects/status/92rb6muqvqw5t6xf?svg=true)](https://ci.appveyor.com/project/GrumpyBusted/grumpy-servicebase)
[![codecov](https://codecov.io/gh/GrumpyBusted/Grumpy.ServiceBase/branch/master/graph/badge.svg)](https://codecov.io/gh/GrumpyBusted/Grumpy.ServiceBase)
[![nuget](https://img.shields.io/nuget/v/Grumpy.ServiceBase.svg)](https://www.nuget.org/packages/Grumpy.ServiceBase/)
[![downloads](https://img.shields.io/nuget/dt/Grumpy.ServiceBase.svg)](https://www.nuget.org/packages/Grumpy.ServiceBase/)

# Grumpy.WindowsService
Base class for building Windows Services, using Topshelf as a Service Host. This base class simplify building cancelable services.

```csharp
public static class Program
{
    private static void Main()
    {
        // One line main procedure
        HostFactory.Run(TopshelfUtility.BuildService(Build));
    }

    // Build your service, you can use the service name
    private static MyService Build(string serviceName)
    {
        return new MyService(serviceName);
    }
}

// Sample Service
public class MyService : ServiceBase
{
    private readonly string _serviceName;
_
    public MyService(string serviceName) 
    {
        _serviceName = serviceName;
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
```