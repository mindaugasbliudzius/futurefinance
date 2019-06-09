using FutureFinanceTree;
using Xunit;

namespace FutureFiannceTreeTests
{
    public class BinaryTreeSolveTests
    {
        [Fact]
        public void DynamycStrategy_CallculateSumShould()
        {
            int[,] nodes = new int[4, 4]
            {
                { 1, 0, 0, 0 },
                { 8, 9, 0, 0 },
                { 1, 5, 9, 0 },
                { 4, 5, 2, 3 }
            };

            IBinaryTree tree = new ArrayTreeReader(nodes).Read();
            long maxSum = new DynamicStrategy().CalculateSum(tree);

            Assert.Equal(16, maxSum);
        }

        [Fact]
        public void BruteForceStrategy_CallculateSumShould()
        {
            int[,] nodes = new int[4, 4]
            {
                { 1, 0, 0, 0 },
                { 8, 9, 0, 0 },
                { 1, 5, 9, 0 },
                { 4, 5, 2, 3 }
            };

            IBinaryTree tree = new ArrayTreeReader(nodes).Read();
            long maxSum = new BruteForceStrategy().CalculateSum(tree);

            Assert.Equal(16, maxSum);
        }
    }
}
