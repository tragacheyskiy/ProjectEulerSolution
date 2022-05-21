namespace ProjectEulerSolution.Problems._1_99._1_9;

// https://projecteuler.net/problem=1
// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
// Find the sum of all the multiples of 3 or 5 below 1000.
internal sealed class Problem1 : IProblem
{
    private const int Number = 1000;

    public void Solve()
    {
        int result = GetMultiplesSum(Number);

        Console.WriteLine($"Sum of all the multiples of 3 or 5 below ({Number}): {result}");
    }

    private int GetMultiplesSum(int number)
    {
        int sum = 0;

        for (int i = 3; i < number; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }

        return sum;
    }
}
