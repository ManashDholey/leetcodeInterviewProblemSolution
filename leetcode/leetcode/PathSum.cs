

namespace leetcode
{
    public class PathSum : DisposableBase
    {



        public bool HasPathSum(TreeNode root, int targetSum)
        {

            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            Stack<int> sumStack = new Stack<int>();

            if (root == null) return false;
            // If it's a leaf node, check if the remaining targetSum equals the node's value
            if (root?.left == null && root?.right == null)
            {
                return targetSum == root?.val;
            }
            nodeStack.Push(root);
            sumStack.Push(root.val);
            while (nodeStack != null && nodeStack?.Count() != 0)
            {
                TreeNode? currentNode = nodeStack?.Pop();
                int currentSum = sumStack?.Pop() ?? 0;
                if (currentNode != null && currentNode?.left == null && currentNode?.right == null && currentSum == targetSum)
                {
                    return true;
                }

                if (currentNode?.right != null)
                {
                    nodeStack?.Push(currentNode?.right);
                    sumStack?.Push(currentSum + currentNode?.right?.val ?? 0);
                }
                if (currentNode?.left != null)
                {
                    nodeStack?.Push(currentNode?.left);
                    sumStack?.Push(currentSum + currentNode?.left?.val ?? 0);
                }
            }
            return false;
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
