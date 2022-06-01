using System.Numerics;

namespace ProjectEulerSolution.Problems._1_99._10_19;

// https://projecteuler.net/problem=15
// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
// How many such routes are there through a 20×20 grid?
internal sealed class Problem15 : IProblem
{
    private readonly record struct Index(int Row, int Column);

    private const int GridSize = 20;

    public void Solve()
    {
        BigInteger result = GetRoutesCount(GridSize);

        Console.WriteLine($"Total routes of {GridSize}x{GridSize} grid: {result}");
    }

    private BigInteger GetRoutesCount(int gridSize)
    {
        BigInteger divisor = GetFactorial(gridSize);

        BigInteger result = GetFactorial(2 * gridSize) / (divisor * divisor);

        return result;
    }

    private BigInteger GetFactorial(int number)
    {
        BigInteger result = 1;

        while (number > 0)
        {
            result *= number--;
        }

        return result;
    }

    private long GetRoutesCountAlternative(int gridSize)
    {
        IDictionary<Index, long> cache = new Dictionary<Index, long>();

        return GetRoutesCountRecursive(0, 0);

        long GetRoutesCountRecursive(int row, int column)
        {
            Index index = new Index(row, column);

            if (cache.ContainsKey(index))
                return cache[index];

            if (row == gridSize && column == gridSize)
                return 1;

            if (!(row < gridSize))
            {
                return GetRoutesCountRecursive(row, column + 1);
            }

            if (!(column < gridSize))
            {
                return GetRoutesCountRecursive(row + 1, column);
            }

            long result = GetRoutesCountRecursive(row + 1, column) + GetRoutesCountRecursive(row, column + 1);

            cache[index] = result;

            return result;
        }
    }
}
