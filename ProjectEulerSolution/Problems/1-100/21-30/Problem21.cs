namespace ProjectEulerSolution.Problems._1_100._21_30;

// https://projecteuler.net/problem=21
// Let d(n) be defined as the sum of proper divisors of n(numbers less than n which divide evenly into n).
// If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284.
// The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
// Evaluate the sum of all the amicable numbers under 10000.
internal sealed class Problem21 : IProblem
{
    private const int AmicableNumberMinValue = 220;
    private const int AmicableNumberMaxValue = 10000;

    public void Solve()
    {
        int result = GetAmicableNumbersSum(AmicableNumberMaxValue);

        Console.WriteLine($"Sum of amicable numbers under ({AmicableNumberMaxValue}): {result}");
    }

    private int GetAmicableNumbersSum(int maxNumber)
    {
        int a = AmicableNumberMinValue;
        int sum = 0;

        while (true)
        {
            int b = GetDivisorsSum(a);
            int x = GetDivisorsSum(b);

            if (x != a || a == b)
            {
                a++;
                continue;
            }

            if (b > maxNumber && x > maxNumber)
            {
                return sum;
            }

            if (a <= maxNumber)
            {
                sum += a;
            }

            if (b <= maxNumber)
            {
                sum += b;
            }

            a = b + 1;
        }
    }

    private int GetDivisorsSum(int number)
    {
        int max = number / 2;
        int sum = 1;

        for (int i = 2; i <= max; i++)
        {
            if (number % i == 0)
            {
                sum += i;
            }
        }

        return sum;
    }
}
