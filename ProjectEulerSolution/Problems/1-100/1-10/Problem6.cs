namespace ProjectEulerSolution.Problems._1_100._1_10;

// https://projecteuler.net/problem=6
// The sum of the squares of the first ten natural numbers is 1^2 + 2^2 + ... + 10^2 = 385.
// The square of the sum of the first ten natural numbers is (1 + 2 + ... + 10)^2 = 55^2 = 3025.
// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
internal sealed class Problem6 : IProblem
{
    private const int MaxNumber = 100;

    public void Solve()
    {
        int numberSquareSum = GetNumberSquareSum(MaxNumber);
        int numberSumSquare = GetNumberSumSquare(MaxNumber);

        int difference = numberSumSquare - numberSquareSum;

        Console.WriteLine($"Difference = {difference}");
    }

    private int GetNumberSquareSum(int maxNumber)
    {
        return maxNumber * (maxNumber + 1) * (2 * maxNumber + 1) / 6;
    }

    private int GetNumberSumSquare(int maxNumber)
    {
        int result = 0;

        for (int i = 1; i <= maxNumber; i++)
        {
            result += i;
        }

        return result * result;
    }
}
