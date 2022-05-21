namespace ProjectEulerSolution.Problems._1_99._1_9;

// https://projecteuler.net/problem=3
// The prime factors of 13195 are 5, 7, 13 and 29.
// What is the largest prime factor of the number 600851475143 ?
internal sealed class Problem3 : IProblem
{
    private const long Number = 600851475143;

    public void Solve()
    {
        int result = GetGreatestPrimeDivisor(Number);

        Console.WriteLine($"Greatest prime divisor of ({Number}): {result}");
    }

    private int GetGreatestPrimeDivisor(long number)
    {
        int max = (int)MathF.Sqrt(number);
        int greatest = -1;

        for (int i = 2; i <= max; i++)
        {
            if (number % i == 0 && IsPrimeNumber(i))
            {
                greatest = i;
            }
        }

        return greatest;
    }

    private bool IsPrimeNumber(int number)
    {
        if (number == 0 || number == 1)
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
