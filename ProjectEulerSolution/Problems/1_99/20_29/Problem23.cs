namespace ProjectEulerSolution.Problems._1_99._20_29;

// https://projecteuler.net/problem=23
// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number.
// For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24.
// By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers.
// However, this upper limit cannot be reduced any further by analysis even though it is known that the
// greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
internal sealed class Problem23 : IProblem
{
    private const int LimitNumber = 20161; // http://mathworld.wolfram.com/AbundantNumber.html
    private const int SmallestAbundantNumber = 12;

    public void Solve()
    {
        int result = GetNumbersSum();

        Console.WriteLine($"Sum of numbers = {result}");
    }

    private int GetNumbersSum()
    {
        int[] abundantNumbers = GetAbundantNumbers();
        var numbersConsistingOfSum = GetNumbersConsistingOfSum(abundantNumbers);

        int sum = 0;

        for (int i = 1; i <= LimitNumber; i++)
        {
            if (numbersConsistingOfSum.Contains(i))
                continue;

            sum += i;
        }

        return sum;
    }

    private HashSet<int> GetNumbersConsistingOfSum(int[] abundantNumbers)
    {
        var result = new HashSet<int>();

        for (int i = 0; i < abundantNumbers.Length; i++)
        {
            for (int j = i; j < abundantNumbers.Length; j++)
            {
                int sum = abundantNumbers[i] + abundantNumbers[j];

                if (sum > LimitNumber)
                    break;

                result.Add(sum);
            }
        }

        return result;
    }

    private int[] GetAbundantNumbers()
    {
        IList<int> result = new List<int>();

        int i = SmallestAbundantNumber;

        result.Add(i);

        while (i++ < LimitNumber)
        {
            if (IsAbundantNumber(i))
            {
                result.Add(i);
            }
        }

        return result.ToArray();
    }

    private bool IsAbundantNumber(int number)
    {
        return GetDivisorsSum(number) > number;
    }

    private int GetDivisorsSum(int number)
    {
        int max = (int)MathF.Sqrt(number);
        int sum = 1;

        for (int i = 2; i <= max; i++)
        {
            if (number % i == 0)
            {
                if (i == max && max * max == number)
                {
                    sum += i;
                    break;
                }

                sum += i + number / i;
            }
        }

        return sum;
    }
}
