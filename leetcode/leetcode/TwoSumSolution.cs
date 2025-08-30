namespace leetcode
{
    public class TwoSumSolution: IDisposable
    {
        private bool disposed = false;
        

        public int[] TwoSum(int[] nums, int target)
        {
           // return TwoSumFun(nums, target);
            return TwoSumFunBest(nums, target);
        }

        private int[] TwoSumFunBest(int[] nums, int target)
        {  //Time Complexcity :O(nlogn) Space:C(1)
            // this solution working for sorted array
            Array.Sort(nums);
            int sum = 0;    
            int left=0, right=nums.Length-1;
            while (left < right) {
                sum = nums[left] + nums[right];
                if (sum == target) {
                    return new int[]{ left,right};
                }
                else if (sum < target) {
                    left += 1;
                }
                else
                {
                    right -= 1;
                }
            }
            return new int[] { -1, -1 };    
        }

        private int[] TwoSumFun(int[] nums, int target)
        {
            //Time Complexcity :O(n) Space:C(n)
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
