using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    
    public class BinaryTreeInorderTraversal : DisposableBase
    {

        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Inorder(root, result);
            return result;
        }

        private void Inorder(TreeNode node, List<int> result)
        {
            if (node == null) return;
            Inorder(node.left, result);
            result.Add(node.val);
            Inorder(node.right, result);
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
