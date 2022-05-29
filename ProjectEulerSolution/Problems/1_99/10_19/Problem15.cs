namespace ProjectEulerSolution.Problems._1_99._10_19;

// https://projecteuler.net/problem=15
// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
// How many such routes are there through a 20×20 grid?
internal sealed class Problem15 : IProblem
{
    private const int GridSize = 20;

    public void Solve()
    {
        long result = GetRoutesCountNew(GridSize);

        Console.WriteLine($"Total routes of {GridSize}x{GridSize} grid: {result}");
    }

    private long GetRoutesCountNew(int gridSize)
    {
        double divisor = GetFactorial(gridSize);

        double result = GetFactorial(2 * gridSize) / (divisor * divisor);

        return (long)result;
    }

    private double GetFactorial(int number)
    {
        double result = 1;

        while (number > 0)
        {
            result *= number--;
        }

        return result;
    }
}
