

namespace leetcode
{
    public class SameTree : DisposableBase
    {

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            // If both are null, they are the same
            if (p == null && q == null) return true;

            // If one is null and the other isn't, they are different
            if (p == null || q == null) return false;

            // If values are different, trees are not same
            if (p.val != q.val) return false;

            // Recursively check left and right subtrees
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
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
