using System;
using System.IO;

namespace FutureFinanceTree
{
    public class FileTreeReader : ITreeReader
    {
        string _path;

        public FileTreeReader(string path)
        {
            _path = path;
        }

        public IBinaryTree Read()
        {
            string[] lines = File.ReadAllLines(_path);

            if (lines.Length == 0)
            {
                throw new Exception("Tree should have at least one node!");
            }

            SimpleTreeNode[,] nodes = new SimpleTreeNode[lines.Length, lines.Length];

            for (int j = 0; j < lines.Length; j++)
            {
                var linePieces = lines[j].Split(' ');

                for (int i = 0; i < linePieces.Length; i++)
                {
                    nodes[j, i] = new SimpleTreeNode() { Value = int.Parse(linePieces[i]), PathDirection = 0 };
                }
            }

            return new SimpleBinaryTree(nodes);
        }
    }
}
