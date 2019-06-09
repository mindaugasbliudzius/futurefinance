using System;

namespace FutureFinanceTree
{
    // idea: https://www.mathblog.dk/project-euler-18/

    public class BruteForceStrategy : ITreeSolveStrategy
    {
        public long CalculateSum(IBinaryTree tree)
        {
            SimpleTreeNode[,] nodes = tree.GetNodes();
            int lines = nodes.GetLength(0);

            SimpleTreeNode[,] preprocessedNodes = new SimpleTreeNode[lines, lines];

            bool topIsEven = nodes[0, 0].Value % 2 == 0;
            bool lineCountIsEven = lines % 2 == 0;

            bool currentLineIsEven = topIsEven;

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    preprocessedNodes[i, j] = new SimpleTreeNode()
                    {
                        Value = (nodes[i, j].Value % 2 == 0) == currentLineIsEven ? nodes[i, j].Value : int.MinValue
                    };
                }

                currentLineIsEven = !currentLineIsEven;
            }

            int posSolutions = (int)Math.Pow(2, preprocessedNodes.GetLength(0) - 1);
            int largestSum = 0;
            int tempSum, index;

            for (int i = 0; i <= posSolutions; i++)
            {
                tempSum = preprocessedNodes[0, 0].Value.Value;
                index = 0;
                for (int j = 0; j < preprocessedNodes.GetLength(0) - 1; j++)
                {
                    index = index + (i >> j & 1);
                    tempSum += preprocessedNodes[j + 1, index].Value.Value;
                }

                if (tempSum > largestSum)
                {
                    largestSum = tempSum;
                }
            }

            return largestSum;
        }

        public IBinaryTree FindPath(IBinaryTree tree)
        {
            throw new NotImplementedException();
        }
    }
}
