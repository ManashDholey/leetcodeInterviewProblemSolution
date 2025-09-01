

namespace leetcode
{
    public class MergeSortedArray:DisposableBase
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;

            // Merge from the back
            while (j >= 0)
            {
                nums1[k--] = (i >= 0 && nums1[i] > nums2[j])
                             ? nums1[i--]
                             : nums2[j--];
            }
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
