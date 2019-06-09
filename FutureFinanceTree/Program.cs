using System;
using System.Diagnostics;

namespace FutureFinanceTree
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                IBinaryTree tree = new FileTreeReader(args[0]).Read();

                Console.WriteLine("Input tree:");
                new TreePrinter().Print(tree);

                Stopwatch clock = Stopwatch.StartNew();

                tree = new DynamicStrategy().FindPath(tree);

                clock.Stop();

                Console.WriteLine("Solved tree:");
                new TreePrinter().PrintWithPath(tree);

                Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
                Console.WriteLine();

                clock = Stopwatch.StartNew();

                long maxSum = new BruteForceStrategy().CalculateSum(tree);

                clock.Stop();

                Console.WriteLine("The largest sum through the triangle by brute force is: {0}", maxSum);
                Console.WriteLine();
                Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
