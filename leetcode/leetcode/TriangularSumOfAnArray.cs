using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class TriangularSumOfAnArray : DisposableBase
    {
        /// <summary>
        /// calculate triangular sum of an array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TriangularSum(int[] nums)
        {
            int n = nums.Length;
            for (int i = n; i>1; i--)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    nums[j] = (nums[j] + nums[j + 1]) % 10;
                }
            }
            return nums[0];

        }







        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources

            }

            // No unmanaged resources, so nothing extra here

            // Call base to set _disposed flag
            base.Dispose(disposing);
        }
    }
}
