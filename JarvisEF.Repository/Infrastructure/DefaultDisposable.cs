using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Repository.Infrastructure
{
    public abstract class DefaultDisposable : IDisposable
    {
        //protected readonly NextProgrammingDataContext context;

        private bool _disposed;
        private readonly object _disposeLock = new object();
        protected DefaultDisposable()
        {
            //context = new NextProgrammingDataContext();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        //context.Dispose();
                    }

                    _disposed = true;
                }
            }
        }
    }
}
