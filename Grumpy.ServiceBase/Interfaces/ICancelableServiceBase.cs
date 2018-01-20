using System;
using System.Diagnostics.CodeAnalysis;

namespace Grumpy.ServiceBase.Interfaces
{
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public interface ICancelableServiceBase : IDisposable
    {
        void Start();
        void StartSync();
        void Stop();
    }
}