

namespace leetcode
{
    internal class MinimumDepthOfBinaryTree : DisposableBase
    {

        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            Queue<(TreeNode node, int depth)> queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, 1));

            while (queue.Count > 0)
            {
                var (node, depth) = queue.Dequeue();

                // Check if it's a leaf node
                if (node.left == null && node.right == null)
                {
                    return depth;
                }

                if (node.left != null) queue.Enqueue((node.left, depth + 1));
                if (node.right != null) queue.Enqueue((node.right, depth + 1));
            }

            return 0; // Should never reach here
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
