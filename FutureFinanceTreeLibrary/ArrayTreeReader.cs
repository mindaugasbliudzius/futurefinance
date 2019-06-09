namespace FutureFinanceTree
{
    public class ArrayTreeReader : ITreeReader
    {
        int[,] _nodes;

        public ArrayTreeReader (int[,] nodes)
        {
            _nodes = nodes;
        }

        public IBinaryTree Read()
        {
            int lines = _nodes.GetLength(0);
            SimpleTreeNode[,] nodes = new SimpleTreeNode[lines, lines];

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    nodes[i, j] = new SimpleTreeNode() { Value = _nodes[i, j], PathDirection = 0 };
                }
            }

            return new SimpleBinaryTree(nodes);
        }
    }
}
