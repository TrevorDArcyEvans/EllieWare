using System;
using System.Threading;

namespace EnterpriseDT.Net.Ftp
{
    internal class FTPSemaphore
    {
        private object syncLock = new object();
        private long count = 0;
        private int waitCount = 0;

        internal FTPSemaphore(int initCount)
        {
            count = initCount;
        }

        internal long Count
        {
            get { return count; }
            set 
            {
                if (value<0)
                    throw new ArgumentOutOfRangeException("count must be non-negative");
                if (value==count)
                    return;
                lock (syncLock)
                {
                    if (count < value)
                        for (; count < value; count++)
                            Monitor.Pulse(syncLock);
                    else // count > value
                        count = value;
                }
            }
        }

        internal int NumWaiting
        {
            get { return waitCount; }
        }

        internal bool WaitOne(int timeoutMillis)
        {
            lock (syncLock)
            {
                bool acquiredLock = false;
                if (count > 0)
                    acquiredLock = true;
                else
                    try
                    {
                        waitCount++;
                        if (timeoutMillis <= 0)
                        {
                            Monitor.Wait(syncLock);
                            acquiredLock = true;
                        }
                        else if (Monitor.Wait(syncLock, timeoutMillis))
                            acquiredLock = true;
                    }
                    finally
                    {
                        waitCount--;
                    }
                if (acquiredLock)
                    count--;
                return acquiredLock;
            }
        }

        internal void Release()
        {
            lock (syncLock)
            {
                count++;
                Monitor.Pulse(syncLock);
            }
        }
    }
}
