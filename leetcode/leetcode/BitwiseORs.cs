

namespace leetcode
{
    public class BitwiseORs : DisposableBase
    {
        public int EvenBitwiseOr(int[] nums)
        {
            int result = 0;
            for(int num =0; num < nums.Length; num ++)
            {
                if (nums[num] % 2 == 0)
                {
                    result |= nums[num]; 
                }
            }
            return result;
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
