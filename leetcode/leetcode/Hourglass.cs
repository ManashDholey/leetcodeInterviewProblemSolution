using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class Hourglass : IDisposable
    {
        private bool disposed = false;

        public  int hourglassSum(List<List<int>> arr)
        {
            var maxSum = int.MinValue;
            for (var i = 0; i < arr.Count - 2; i++)
            {
                for (var j = 0; j < arr.Count - 2; j++)
                {
                    var currentSum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2]              // 1 row
                                      + arr[i + 1][j + 1]                                      // 2 row
                                      + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2]; // 3 row

                    maxSum = maxSum < currentSum
                        ? currentSum
                        : maxSum;
                }
            }

            return maxSum;
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
