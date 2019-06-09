namespace FutureFinanceTree
{
    public class SimpleTreeNode
    {
        public int? Value { get; set; }
        public int PathDirection { get; set; } // 0 - left; 1 - rigth;

        public SimpleTreeNode()
        {
            PathDirection = 0;
        }

        public SimpleTreeNode(SimpleTreeNode node)
        {
            Value = node.Value;
            PathDirection = node.PathDirection;
        }
    }

    public class SimpleBinaryTree : IBinaryTree
    {
        SimpleTreeNode[,] _nodes;

        public SimpleBinaryTree(SimpleTreeNode[,] nodes)
        {
            _nodes = nodes;
        }

        public SimpleTreeNode[,] GetNodes()
        {
            return _nodes;
        }
    }
}
