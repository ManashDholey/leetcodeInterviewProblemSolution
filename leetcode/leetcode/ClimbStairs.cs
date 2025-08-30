

namespace leetcode
{
    public class ClimbStairs : IDisposable
    {
        private bool disposed = false;

        public int ClimbStairsFun(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            int a = 1, b = 2, c = 0;
            for (int i = 2; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
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
