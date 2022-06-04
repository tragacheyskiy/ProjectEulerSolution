namespace ProjectEulerSolution.Problems._1_99._20_29;

// https://projecteuler.net/problem=28
// Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
// 21 22 23 24 25
// 20  7  8  9 10
// 19  6  1  2 11
// 18  5  4  3 12
// 17 16 15 14 13
// It can be verified that the sum of the numbers on the diagonals is 101.
// What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
internal sealed class Problem28 : IProblem
{
    private enum Direction { Left, Right, Up, Down };
    private readonly record struct Index(int Row, int Column, Direction Direction);

    private const int GridSize = 1001;

    public void Solve()
    {
        int[,] grid = GetGrid(GridSize);

        long result = GetDiagonalSum(grid);

        Console.WriteLine($"Sum of the numbers on the diagonals in {GridSize}x{GridSize} grid: {result}");
    }

    private long GetDiagonalSum(int[,] grid)
    {
        int gridSize = grid.GetLength(0);
        long result = 0;

        for (int i = 0, j = gridSize - 1; i < gridSize; i++, j--)
        {
            if (i == j)
            {
                result += grid[i, i];
                continue;
            }

            result += grid[i, i] + grid[i, j];
        }

        return result;
    }

    private int[,] GetGrid(int size)
    {
        int[,] grid = new int[size, size];
        int number = 1;

        Index currentIndex = new Index((size - 1) / 2, (size - 1) / 2, Direction.Up);

        do
        {
            grid[currentIndex.Row, currentIndex.Column] = number++;
        }
        while (TryGetNextIndex(grid, currentIndex, out currentIndex));

        return grid;
    }

    private bool TryGetNextIndex(int[,] grid, Index currentIndex, out Index nextIndex) => currentIndex.Direction switch
    {
        Direction.Right => TryGetNextRightIndex(grid, currentIndex, out nextIndex),
        Direction.Up => TryGetNextUpIndex(grid, currentIndex, out nextIndex),
        Direction.Down => TryGetNextDownIndex(grid, currentIndex, out nextIndex),
        _ => TryGetNextLeftIndex(grid, currentIndex, out nextIndex)
    };

    private bool TryGetNextRightIndex(int[,] grid, Index currentIndex, out Index nextIndex)
    {
        (int row, int column, Direction direction) = currentIndex;

        if (IsEmpty(grid[row + 1, column]))
        {
            nextIndex = new Index(row + 1, column, Direction.Down);
            return true;
        }

        if (IsFullGrid(grid, currentIndex))
        {
            nextIndex = default;
            return false;
        }

        nextIndex = new Index(row, column + 1, direction);
        return true;
    }

    private bool TryGetNextDownIndex(int[,] grid, Index currentIndex, out Index nextIndex)
    {
        (int row, int column, Direction direction) = currentIndex;

        if (IsEmpty(grid[row, column - 1]))
        {
            nextIndex = new Index(row, column - 1, Direction.Left);
            return true;
        }

        if (IsFullGrid(grid, currentIndex))
        {
            nextIndex = default;
            return false;
        }

        nextIndex = new Index(row + 1, column, direction);
        return true;
    }

    private bool TryGetNextLeftIndex(int[,] grid, Index currentIndex, out Index nextIndex)
    {
        (int row, int column, Direction direction) = currentIndex;

        if (IsEmpty(grid[row - 1, column]))
        {
            nextIndex = new Index(row - 1, column, Direction.Up);
            return true;
        }

        if (IsFullGrid(grid, currentIndex))
        {
            nextIndex = default;
            return false;
        }

        nextIndex = new Index(row, column - 1, direction);
        return true;
    }

    private bool TryGetNextUpIndex(int[,] grid, Index currentIndex, out Index nextIndex)
    {
        (int row, int column, Direction direction) = currentIndex;

        if (IsEmpty(grid[row, column + 1]))
        {
            nextIndex = new Index(row, column + 1, Direction.Right);
            return true;
        }

        if (IsFullGrid(grid, currentIndex))
        {
            nextIndex = default;
            return false;
        }

        nextIndex = new Index(row - 1, column, direction);
        return true;
    }

    private bool IsEmpty(int value) => value == 0;

    private bool IsFullGrid(int[,] grid, Index index)
    {
        if (index.Direction == Direction.Right)
            return index.Column == grid.GetLength(0) - 1;

        if (index.Direction == Direction.Down)
            return index.Row == grid.GetLength(1) - 1;

        if (index.Direction == Direction.Left)
            return index.Column == 0;

        return index.Row == 0;
    }
}
