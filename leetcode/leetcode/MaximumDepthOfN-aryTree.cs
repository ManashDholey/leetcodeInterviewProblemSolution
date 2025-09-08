

namespace leetcode
{
    public class MaximumDepthOfN_aryTree : DisposableBase
    {
        public int MaxDepth(Node root)
        {
            if (root == null) return 0;

            int max = 0;
            foreach (var child in root.children)
            {
                max = Math.Max(max, MaxDepth(child));
            }

            return max + 1; // add current node depth
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
