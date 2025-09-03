

namespace leetcode
{
    public class ConvertSortedArrayToBinarySearchTree : DisposableBase
    {


        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;
            return BuildBST(nums, 0, nums.Length - 1);
        }

        private TreeNode BuildBST(int[] nums, int left, int right)
        {
            if (left > right) return null;

            // Pick middle element
            int mid = left + (right - left) / 2;

            TreeNode node = new TreeNode(nums[mid]);
            node.left = BuildBST(nums, left, mid - 1);
            node.right = BuildBST(nums, mid + 1, right);

            return node;
        }

        public void PrintTree(TreeNode root, string indent = "", bool isLeft = true)
        {
            if (root == null) return;

            PrintTree(root.right, indent + (isLeft ? "│   " : "    "), false);
            Console.WriteLine(indent + (isLeft ? "└── " : "┌── ") + root.val);
            PrintTree(root.left, indent + (isLeft ? "    " : "│   "), true);
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
