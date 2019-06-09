namespace FutureFinanceTree
{
    public interface ITreeSolveStrategy
    {
        IBinaryTree FindPath(IBinaryTree tree);
        long CalculateSum(IBinaryTree tree);
    }
}
