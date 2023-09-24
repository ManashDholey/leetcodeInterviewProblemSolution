using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class BirthdayCakeCandles : IDisposable
    {
        private bool disposed = false;

        public  int birthdayCakeCandles(List<int> candles)
        {
            int maxValue = candles.Max();
            int Count = 0;
            foreach (var item in candles)
            {
                if (item == maxValue)
                {
                    Count++;
                }
            }
            return Count;
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
