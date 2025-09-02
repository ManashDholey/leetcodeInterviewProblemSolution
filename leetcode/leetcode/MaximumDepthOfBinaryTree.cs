

namespace leetcode
{
    public class MaximumDepthOfBinaryTree:DisposableBase
    {

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return Math.Max( MaxDepth(root.left), MaxDepth(root.right)) + 1;
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
