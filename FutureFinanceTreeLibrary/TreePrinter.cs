using System;
using System.Linq;

namespace FutureFinanceTree
{
    public interface ITreePrinter
    {
        void PrintWithPath(IBinaryTree tree);
        void Print(IBinaryTree tree);
    }

    public class TreePrinter : ITreePrinter
    {
        public void Print(IBinaryTree tree)
        {
            Console.WriteLine();

            SimpleTreeNode[,] nodes = tree.GetNodes();
            int lines = nodes.GetLength(0);

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write((nodes[i, j].Value + " ").PadRight(6, ' '));
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void PrintWithPath(IBinaryTree tree)
        {
            Console.WriteLine();

            SimpleTreeNode[,] nodes = tree.GetNodes();
            int lines = nodes.GetLength(0);
            int pathIndex = 0;
            int nextPathIndex = 0;
            int[] pathValues = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (pathIndex == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        nextPathIndex = pathIndex + nodes[i, j].PathDirection;
                        pathValues[i] = nodes[i, j].Value.Value;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.Write((nodes[i, j].Value + " ").PadRight(6, ' '));
                }

                Console.WriteLine();
                pathIndex = nextPathIndex;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(string.Join(" + ", pathValues));
            Console.WriteLine(" = " + pathValues.Sum());
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();
        }
    }
}
