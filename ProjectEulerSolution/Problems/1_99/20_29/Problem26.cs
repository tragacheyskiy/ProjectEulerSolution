namespace ProjectEulerSolution.Problems._1_99._20_29;

// https://projecteuler.net/problem=26
// A unit fraction contains 1 in the numerator.
// The decimal representation of the unit fractions with denominators 2 to 10 are given:
// 1/2  =  0.5
// 1/3	=  0.(3)
// 1/4	=  0.25
// 1/5	=  0.2
// 1/6	=  0.1(6)
// 1/7	=  0.(142857)
// 1/8	=  0.125
// 1/9	=  0.(1)
// 1/10	=  0.1
// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle.
// It can be seen that 1/7 has a 6-digit recurring cycle.
// Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
internal sealed class Problem26 : IProblem
{
    private const int LimitNumber = 1000;

    public void Solve()
    {
        int result = GetLongestRecurringCycleNumber(LimitNumber);

        Console.WriteLine($"Divisor of longest recurring cycle = {result}");
    }

    private int GetLongestRecurringCycleNumber(int limitNumber)
    {
        int divisorOfMaxLength = 0;
        int maxLength = 0;

        for (int i = 2; i < limitNumber; i++)
        {
            int length = GetRecurringCycleLength(i);

            if (length > maxLength)
            {
                divisorOfMaxLength = i;
                maxLength = length;
            }
        }

        return divisorOfMaxLength;
    }

    private int GetRecurringCycleLength(int divisor)
    {
        int length = 0;

        if (divisor % 10 == 0)
            return length;

        IList<int> remainders = new List<int>();

        int numerator = 1;
        int remainder;

        while ((remainder = numerator % divisor) != 0)
        {
            if (remainders.Contains(remainder))
            {
                length = remainders.Count - remainders.IndexOf(remainder);
                break;
            }

            remainders.Add(remainder);
            numerator = remainder * 10;
        }

        return length;
    }
}
