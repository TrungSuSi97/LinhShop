using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinhNguyen.Common
{
    public class MultiThreadPool : IDisposable
    {
        private readonly LinkedList<Thread> _wokers; // queue of worker threads ready to process actions
        private readonly LinkedList<Action> _task = new LinkedList<Action>(); // actions to be processed by worker threads
        private bool _disallowAdd; // set to true when disposing queue but there are still tasks pending
        private bool _disposed;
        public MultiThreadPool(int size)
        {
            this._wokers = new LinkedList<Thread>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
