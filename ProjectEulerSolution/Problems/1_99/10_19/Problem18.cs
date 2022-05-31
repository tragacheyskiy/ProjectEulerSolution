using ProjectEulerSolution.Resources;
using System.Reflection;

namespace ProjectEulerSolution.Problems._1_99._10_19;

// https://projecteuler.net/problem=18
// By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.
//    3
//   7 4
//  2 4 6
// 8 5 9 3
// That is, 3 + 7 + 4 + 9 = 23.
// Find the maximum total from top to bottom of the triangle below:
// ...
// NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route.
// However, Problem 67, is the same challenge with a triangle containing one-hundred rows;
// it cannot be solved by brute force, and requires a clever method! ; o)
internal sealed class Problem18 : IProblem
{
    private class PathSum
    {
        public PathSum(int sum, byte[] path)
        {
            Sum = sum;
            Path = path;
        }

        public int Sum { get; }
        public byte[] Path { get; }
    }

    private struct Index
    {
        public Index(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }
    }

    public void Solve()
    {
        byte[][] tree = GetTree();

        PathSum result = GetMaxPathSumAlternative(tree);

        string pathString = $"[{string.Join(", ", result.Path)}]";

        Console.WriteLine($"Path: {pathString}\n\nSum: {result.Sum}");
    }

    private PathSum GetMaxPathSumAlternative(byte[][] tree)
    {
        IDictionary<Index, PathSum> cache = new Dictionary<Index, PathSum>();
        List<byte> currentPath = new List<byte>();

        int max = tree[^1].Length;

        for (int column = 0; column < max; column++)
        {
            int sum = 0;
            byte currentValue;

            for (int row = column; row < tree.Length; row++)
            {
                currentValue = tree[row][column];

                if (column == 0)
                {
                    sum += currentValue;

                    currentPath.Add(currentValue);

                    cache.Add(new Index(row, column), new PathSum(sum, currentPath.ToArray()));

                    continue;
                }

                var left = cache[new Index(row - 1, column - 1)];
                int leftSum = currentValue + left.Sum;

                if (row == column)
                {
                    sum += leftSum;

                    currentPath.AddRange(left.Path);
                    currentPath.Add(currentValue);

                    cache.Add(new Index(row, column), new PathSum(sum, currentPath.ToArray()));

                    currentPath.Clear();

                    continue;
                }

                sum = 0;

                var right = cache[new Index(row - 1, column)];
                int rightSum = currentValue + right.Sum;

                sum += leftSum > rightSum ? leftSum : rightSum;

                currentPath.AddRange(leftSum > rightSum ? left.Path : right.Path);
                currentPath.Add(currentValue);

                cache.Add(new Index(row, column), new PathSum(sum, currentPath.ToArray()));

                currentPath.Clear();
            }

            if (column == 0)
            {
                currentPath.Clear();
            }
        }

        PathSum maxSum = cache[new Index(max - 1, 0)];

        for (int i = 1; i < max; i++)
        {
            var sum = cache[new Index(max - 1, i)];

            if (sum.Sum > maxSum.Sum)
            {
                maxSum = sum;
            }
        }

        return maxSum;
    }

    private int GetMaxPathSum(byte[][] tree)
    {
        IDictionary<Index, int> cache = new Dictionary<Index, int>();

        int row = tree.GetLength(0) - 1;
        int columns = tree[row].Length;
        int maxSum = 0;

        for (int i = 0; i < columns; i++)
        {
            int result = GetMaxPathSumRecursive(tree, row, i);

            if (result > maxSum)
            {
                maxSum = result;
            }
        }

        return maxSum;

        int GetMaxPathSumRecursive(byte[][] tree, int row, int column)
        {
            Index index = new Index(row, column);
            byte currentValue = tree[row][column];

            if (cache.ContainsKey(index))
                return cache[index];

            if (row == 0 && column == 0)
                return currentValue;

            int left, right;

            if (column == 0)
            {
                right = currentValue + GetMaxPathSumRecursive(tree, row - 1, column);

                cache[index] = right;
                return right;
            }

            if (column == tree[row].Length - 1)
            {
                left = currentValue + GetMaxPathSumRecursive(tree, row - 1, column - 1);

                cache[index] = left;
                return left;
            }

            left = currentValue + GetMaxPathSumRecursive(tree, row - 1, column - 1);
            right = currentValue + GetMaxPathSumRecursive(tree, row - 1, column);

            if (left > right)
            {
                cache[index] = left;
                return left;
            }

            cache[index] = right;
            return right;
        }
    }

    private byte[][] GetTree()
    {
        using Stream? stream = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream(ResourceNames.Problem18.Name);

        if (stream == null)
            return Array.Empty<byte[]>();

        string result;

        using (StreamReader streamReader = new StreamReader(stream))
        {
            result = streamReader.ReadToEnd();
        };

        string[] rows = result.Split('\n');
        byte[][] tree = new byte[rows.Length][];

        for (int i = 0; i < rows.Length; i++)
        {
            string[] columns = rows[i].Split(' ');

            tree[i] = new byte[columns.Length];

            for (int j = 0; j < columns.Length; j++)
            {
                tree[i][j] = byte.Parse(columns[j]);
            }
        }

        return tree;
    }
}
