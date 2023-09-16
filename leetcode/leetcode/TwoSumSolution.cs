using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class TwoSumSolution: IDisposable
    {
        private bool disposed = false;
        

        public int[] TwoSum(int[] nums, int target)
        {
            return TwoSumFun(nums, target);
        }
        private int[] TwoSumFun(int[] nums, int target)
        {
            // Create a dictionary to store elements and their indices
            Dictionary<int, int> numIndices = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                // If the complement exists in the dictionary, return its index along with the current index
                if (numIndices.ContainsKey(complement))
                {
                    return new int[] { numIndices[complement], i };
                }

                // Otherwise, add the current element and its index to the dictionary
                if (!numIndices.ContainsKey(nums[i]))
                {
                    numIndices[nums[i]] = i;
                }
            }

            // If no solution is found, return an empty array or throw an exception as needed
            return new int[0]; // No solution found
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
