namespace FutureFinanceTree
{
    // idea: https://www.mathblog.dk/project-euler-18/

    public class DynamicStrategy : ITreeSolveStrategy
    {
        SimpleTreeNode[,] _preprocessedNodes;
        SimpleTreeNode[,] _largestValues;

        public long CalculateSum(IBinaryTree tree)
        {
            FindPath(tree);
            return _largestValues[0, 0].Value.Value;
        }

        public IBinaryTree FindPath(IBinaryTree tree)
        {
            SimpleTreeNode[,] nodes = tree.GetNodes();
            int lines = nodes.GetLength(0);

            _preprocessedNodes = new SimpleTreeNode[lines, lines];
            _largestValues = new SimpleTreeNode[lines, lines];

            bool topIsEven = nodes[0, 0].Value % 2 == 0;
            bool lineCountIsEven = lines % 2 == 0;

            bool currentLineIsEven = topIsEven;

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    _largestValues[i, j] = new SimpleTreeNode(nodes[i, j]);
                    _preprocessedNodes[i, j] = new SimpleTreeNode()
                    {
                        Value = (nodes[i, j].Value % 2 == 0) == currentLineIsEven ? nodes[i, j].Value : (int?)null
                    };
                }

                currentLineIsEven = !currentLineIsEven;
            }

            for (int i = lines - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    int? left = _preprocessedNodes[i + 1, j].Value;
                    int? rigth = _preprocessedNodes[i + 1, j + 1].Value;

                    if (!left.HasValue)
                    {
                        _largestValues[i, j].Value += _largestValues[i + 1, j + 1].Value;
                        nodes[i, j].PathDirection = 1;
                    }
                    else if (!rigth.HasValue)
                    {
                        _largestValues[i, j].Value += _largestValues[i + 1, j].Value;
                    }
                    else
                    {
                        if (_largestValues[i + 1, j].Value.Value > _largestValues[i + 1, j + 1].Value.Value)
                        {
                            _largestValues[i, j].Value += _largestValues[i + 1, j].Value;
                        }
                        else
                        {
                            _largestValues[i, j].Value += _largestValues[i + 1, j + 1].Value;
                            nodes[i, j].PathDirection = 1;
                        }
                    }
                }
            }

            return tree;
        }
    }
}
