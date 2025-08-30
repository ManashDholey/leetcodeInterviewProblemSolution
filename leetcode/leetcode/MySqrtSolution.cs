

namespace leetcode
{
    public class MySqrtSolution:IDisposable
    {
        private bool disposed = false;
        public int MySqrt(int x)
        {
            int first = 0, last = x;
            while (first <= last)
            {
                long mid = (first + last) / 2, temp = mid * mid;
                if (x == temp)
                    return (int)mid;
                else if (temp > x)
                    last = (int)(mid - 1);
                else
                    first = (int)(mid + 1);
            }
            return last;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                //if (disposing)
                //{
                //    // Dispose managed resources.

                //}
                // Note disposing has been done.
                disposed = true;
            }
        }
    }
}
