using ProjectEulerSolution.Resources;
using System.Reflection;

namespace ProjectEulerSolution.Problems._1_99._10_19;

// https://projecteuler.net/problem=11
// In the 20×20 grid below, four numbers along a diagonal line have been marked in red.
// The product of these numbers is 26 × 63 × 78 × 14 = 1788696.
// What is the greatest product of four adjacent numbers in the same direction(up, down, left, right, or diagonally) in the 20×20 grid?
internal sealed class Problem11 : IProblem
{
    private class SequenceProduct
    {
        public SequenceProduct(int[] sequence, int product)
        {
            Sequence = sequence;
            Product = product;
        }

        public int[] Sequence { get; }
        public int Product { get; }
    }

    private const int SequenceLength = 4;

    public void Solve()
    {
        int[,] grid = GetGrid();

        SequenceProduct result = GetGreatestSequenceProduct(grid);

        string sequenceString = string.Join(" x ", result.Sequence);

        Console.WriteLine($"{sequenceString} = {result.Product}");
    }

    private SequenceProduct GetGreatestSequenceProduct(int[,] grid)
    {
        int max = grid.GetLength(0);
        ReadOnlySpan<int> sequence = default;
        int greatestSequenceProduct = 0;

        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max - SequenceLength; j++)
            {
                if (grid[i, j] == 0)
                    continue;

                int[] supposedSequence = GetHorizontalLine(grid, i, j);
                CheckSequence(supposedSequence, ref sequence, ref greatestSequenceProduct);

                if (i > max - SequenceLength)
                    continue;

                supposedSequence = GetVerticalLine(grid, i, j);
                CheckSequence(supposedSequence, ref sequence, ref greatestSequenceProduct);

                supposedSequence = GetRightDiagonal(grid, i, j);
                CheckSequence(supposedSequence, ref sequence, ref greatestSequenceProduct);

                if (j - SequenceLength - 1 < 0)
                    continue;

                supposedSequence = GetLeftDiagonal(grid, i, j);
                CheckSequence(supposedSequence, ref sequence, ref greatestSequenceProduct);
            }
        }

        return new SequenceProduct(sequence.ToArray(), greatestSequenceProduct);
    }

    private void CheckSequence(
        ReadOnlySpan<int> supposedSequence,
        ref ReadOnlySpan<int> sequenceOfGreatestProduct,
        ref int greatestSequenceProduct)
    {
        int sequenceProduct = GetSequenceProduct(supposedSequence);

        if (sequenceProduct > greatestSequenceProduct)
        {
            greatestSequenceProduct = sequenceProduct;
            sequenceOfGreatestProduct = supposedSequence;
        }
    }

    private int[] GetHorizontalLine(int[,] grid, int row, int column)
    {
        int[] result = new int[SequenceLength];

        for (int i = 0; i < SequenceLength; i++)
        {
            result[i] = grid[row, column + i];
        }

        return result;
    }

    private int[] GetVerticalLine(int[,] grid, int row, int column)
    {
        int[] result = new int[SequenceLength];

        for (int i = 0; i < SequenceLength; i++)
        {
            result[i] = grid[row + i, column];
        }

        return result;
    }

    private int[] GetRightDiagonal(int[,] grid, int row, int column)
    {
        int[] result = new int[SequenceLength];

        for (int i = 0; i < SequenceLength; i++)
        {
            result[i] = grid[row + i, column + i];
        }

        return result;
    }

    private int[] GetLeftDiagonal(int[,] grid, int row, int column)
    {
        int[] result = new int[SequenceLength];

        for (int i = 0; i < SequenceLength; i++)
        {
            result[i] = grid[row + i, column - i];
        }

        return result;
    }

    private int GetSequenceProduct(ReadOnlySpan<int> sequence)
    {
        int result = 1;

        foreach (int number in sequence)
        {
            result *= number;
        }

        return result;
    }

    private int[,] GetGrid()
    {
        using Stream? stream = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream(ResourceNames.Problem11.Name);

        if (stream == null)
            return new int[0, 0];

        string result;

        using (StreamReader streamReader = new StreamReader(stream))
        {
            result = streamReader.ReadToEnd();
        };

        string[] rows = result.Split('\n');
        int[,] grid = new int[rows.Length, rows.Length];

        for (int i = 0; i < rows.Length; i++)
        {
            int j = 0;

            foreach (string element in rows[i].Split(' '))
            {
                grid[i, j++] = int.Parse(element);
            }
        }

        return grid;
    }
}
