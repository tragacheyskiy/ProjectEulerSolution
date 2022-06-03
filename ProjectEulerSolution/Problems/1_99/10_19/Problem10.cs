namespace ProjectEulerSolution.Problems._1_99._10_19;

// https://projecteuler.net/problem=10
// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
// Find the sum of all the primes below two million.
internal sealed class Problem10 : IProblem
{
    private const int MaxPrimeNumber = 2000000;

    public void Solve()
    {
        long result = GetPrimeNumbersSum(MaxPrimeNumber);

        Console.WriteLine($"Prime numbers below ({MaxPrimeNumber}) sum = {result}");
    }

    private long GetPrimeNumbersSum(int limit)
    {
        long result = 0;
        int i = 1;

        while (i++ <= limit)
        {
            if (IsPrimeNumber(i))
            {
                result += i;
            }
        }

        return result;
    }

    private bool IsPrimeNumber(int number)
    {
        if (number <= 0 || number == 1)
            return false;

        int max = (int)MathF.Sqrt(number);

        for (int i = 2; i <= max; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}
