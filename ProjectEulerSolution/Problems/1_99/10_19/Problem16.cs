namespace ProjectEulerSolution.Problems._1_99._10_19;

// https://projecteuler.net/problem=16
// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
// What is the sum of the digits of the number 2^1000?
internal sealed class Problem16 : IProblem
{
    private const int PowerValue = 1000;

    public void Solve()
    {
        double number = Math.Pow(2, PowerValue);
        var result = GetDigitSum(number);

        Console.WriteLine($"Sum of digits of 2^{PowerValue}: {result}");
    }

    private double GetDigitSum(double number)
    {
        ReadOnlySpan<char> numberStr = number.ToString("F0");

        int result = 0;

        foreach (char digit in numberStr)
        {
            result += (int)char.GetNumericValue(digit);
        }

        return result;
    }
}
