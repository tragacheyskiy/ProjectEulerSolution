using System.Numerics;

namespace ProjectEulerSolution.Problems._1_99._20_29;

// https://projecteuler.net/problem=20
// n! means n × (n − 1) × ... × 3 × 2 × 1
// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
// Find the sum of the digits in the number 100!
internal sealed class Problem20 : IProblem
{
    private const int Number = 100;

    public void Solve()
    {
        int result = GetFactorialDigitsSum(Number);

        Console.WriteLine($"Sum of the digits of {Number}!: {result}");
    }

    private int GetFactorialDigitsSum(int number)
    {
        string factorial = GetFactorial(number).ToString();

        int result = 0;

        foreach (char digit in factorial)
        {
            result += digit - '0';
        }

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
}
