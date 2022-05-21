namespace ProjectEulerSolution.Problems._1_99._1_9;

// https://projecteuler.net/problem=4
// A palindromic number reads the same both ways.
// The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
// Find the largest palindrome made from the product of two 3-digit numbers.
internal sealed class Problem4 : IProblem
{
    private const int MinNumber = 100;
    private const int MaxNumber = 999;

    public void Solve()
    {
        int result = GetLargestPalindrome();

        Console.WriteLine($"Largest palindrome = {result}");
    }

    private int GetLargestPalindrome()
    {
        int largest = 0;

        for (int i = MinNumber; i <= MaxNumber; i++)
        {
            for (int j = MinNumber; j <= MaxNumber; j++)
            {
                int x = i * j;

                if (!IsPalindrome(x))
                    continue;

                if (x > largest)
                {
                    largest = x;
                }
            }
        }

        return largest;
    }

    private bool IsPalindrome(int number)
    {
        ReadOnlySpan<char> digits = number.ToString();

        for (int i = 0; i < digits.Length / 2; i++)
        {
            if (digits[i] != digits[^(i + 1)])
            {
                return false;
            }
        }

        return true;
    }
}
