

namespace leetcode
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node()
        {
            children = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            children = new List<Node>();
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
