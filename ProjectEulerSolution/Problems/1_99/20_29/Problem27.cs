namespace ProjectEulerSolution.Problems._1_99._20_29;

// https://projecteuler.net/problem=27
// Euler discovered the remarkable quadratic formula: n^2 + n + 41
// It turns out that the formula will produce 40 primes for the consecutive integer values 0 ≤ n ≤ 39.
// However, when n = 40, 40^2 + 40 + 41 = 40(40 + 1) + 41 is clearly divisible by 41.
// The incredible formula n^2 − 79n + 1601 was discovered, which produces 80 primes for the consecutive values 0 ≤ n ≤ 79.
// The product of the coefficients, −79 and 1601, is −126479.
// Considering quadratics of the form:
// n^2 + an + b , where |a| < 1000 and |b| ≤ 1000
// where |n| is the modulus/absolute value of n
// e.g. |11| = 11 and |−4| = 4
// Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for
// consecutive values of n, starting with n = 0.
internal sealed class Problem27 : IProblem
{
    private readonly record struct Coefficients(int A, int B);

    private const int MaxA = 1000;
    private const int MaxB = 1000;

    public void Solve()
    {
        var result = GetCoefficientsOfMaxPrimeNumbers(MaxA, MaxB);

        Console.WriteLine($"{result.A} x {result.B} = {result.A * result.B}");
    }

    private Coefficients GetCoefficientsOfMaxPrimeNumbers(int maxA, int maxB)
    {
        Coefficients result = default;
        int primesMaxCount = 0;

        for (int i = 1 - maxA; i < maxA; i++)
        {
            for (int j = 0 - maxB; j <= maxB; j++)
            {
                var coefficients = new Coefficients(i, j);
                int number = 0;
                int primesCount = 0;

                while (IsPrimeNumber(CalculateIncredibleFormula(number++, coefficients)))
                {
                    primesCount++;
                }

                if (primesCount > primesMaxCount)
                {
                    primesMaxCount = primesCount;
                    result = coefficients;
                }
            }
        }

        return result;
    }

    private int CalculateIncredibleFormula(int number, Coefficients coefficients)
    {
        return number * number + coefficients.A * number + coefficients.B;
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
