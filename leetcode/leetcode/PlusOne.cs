

namespace leetcode
{
    public class PlusOne : IDisposable
    {
        private bool disposed = false;
        public int[] PlusOneFun(int[] digits)
        {
            int i = digits.Length - 1;
            while (digits[i] == 9)
            {
                digits[i] = 0;
                if (i == 0)
                {
                    var newDigits = new int[digits.Length + 1];
                    newDigits[0] = 1;
                    return newDigits;
                }
                i--;
            }
            digits[i] += 1;
            return digits;
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
