using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace JarvisEF.FrontUI.Global
{
    /// <summary>
    /// https://gist.github.com/icanhasjonas/bdacabee5898f3ec91603945847a2e22
    /// </summary>
    public static class AwaitableCancellationTokenExtensions
    {
        public struct CancellationTokenAwaiter : ICriticalNotifyCompletion, INotifyCompletion
        {
            private readonly CancellationToken _cancellationToken;
            public CancellationTokenAwaiter(CancellationToken cancellationToken)
            {
                _cancellationToken = cancellationToken;
            }

            public void OnCompleted(Action continuation) => _cancellationToken.Register(continuation, false);
            public void UnsafeOnCompleted(Action continuation) => OnCompleted(continuation);
            public bool IsCompleted => _cancellationToken.IsCancellationRequested;
            public void GetResult() { }
        }

        public static CancellationTokenAwaiter GetAwaiter(this CancellationToken c) => new CancellationTokenAwaiter(c);
    }
}
