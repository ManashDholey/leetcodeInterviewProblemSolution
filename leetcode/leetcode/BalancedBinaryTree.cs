

namespace leetcode
{
    public class BalancedBinaryTree: DisposableBase
    {
        public bool IsBalanced(TreeNode root)
        {
            return CheckHeight(root) != -1;
        }

        private int CheckHeight(TreeNode node)
        {
            if (node == null) return 0;

            int leftHeight = CheckHeight(node.left);
            if (leftHeight == -1) return -1;  // Left not balanced

            int rightHeight = CheckHeight(node.right);
            if (rightHeight == -1) return -1; // Right not balanced

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1; // Not balanced

            return Math.Max(leftHeight, rightHeight) + 1;
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
