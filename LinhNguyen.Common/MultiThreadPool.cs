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
        private bool _disposed; // set to true when disposing queue and no more tasks are pending
        public MultiThreadPool(int size)
        {
            this._wokers = new LinkedList<Thread>();
            for (int i = 0; i < size ; i++)
            {
                var worker = new Thread(this.Worker);
            }
        }

        public void Dispose()
        {
            var waitForThreads = false;
            lock (this._task)
            {
                if (!this._disposed)
                {
                    GC.SuppressFinalize(this);
                    // wait for all tasks to finish processing while not allowing any more new tasks
                    this._disallowAdd = true;
                    while (this._task.Count >0)
                    {
                        Monitor.Wait(this._task);
                    }

                    this._disposed = true;
                    // wake all workers (none of them will be active at this point; 
                    //disposed flag will cause then to finish so that we can join them)
                    Monitor.PulseAll(this._task);
                }
            }
        }

        public void QueueTask(Action task)
        {
            lock (this._task)
            {
                if (this._disallowAdd)
                {
                    throw new InvalidOperationException("This Pool instance is in the process of being disposed, can't add anymore");
                }
                if (this._disposed)
                {
                    throw new ObjectDisposedException("This Pool instance has already been disposed");
                }
                this._task.AddLast(task);
                Monitor.PulseAll(this._task); // pulse because tasks count changed
            }
        }
        

        private void Worker()
        {
            Action task = null;
            while (true) // loop until thread is disposed
            {
                lock (this._task) // Finding a task need to be atomic
                {
                    while (true) // Waiting for turn in _workers queue and an available task
                    {
                        if (this._disposed)
                        {
                            return;
                        }
                        if (null != this._wokers.First 
                            && object.ReferenceEquals(Thread.CurrentThread, this._wokers.First.Value)
                            && this._task.Count > 0)
                        // we can only claim a task if its our turn (this worker thread is the first entry in _worker queue) and there is a task available
                        {
                            task = this._task.First.Value;
                            this._task.RemoveFirst();
                            this._wokers.RemoveFirst();
                            // pulse because current (First) worker changed (so that next available sleeping worker will pick up its task)
                            Monitor.PulseAll(this._wokers);
                            // we found a task to process, break out from the above 'while (true)' loop
                            break;
                        }
                        Monitor.Wait(this._task); // go to sleep, either not our turn or no task to process
                    }
                }
                // process the found task
                task();
                lock (this._task)
                {
                    this._wokers.AddLast(Thread.CurrentThread);
                }
                task = null;
            }
        }
    }
}
