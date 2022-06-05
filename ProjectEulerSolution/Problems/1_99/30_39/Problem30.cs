namespace ProjectEulerSolution.Problems._1_99._30_39;

// https://projecteuler.net/problem=30
// Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
// 1634 = 1^4 + 6^4 + 3^4 + 4^4
// 8208 = 8^4 + 2^4 + 0^4 + 8^4
// 9474 = 9^4 + 4^4 + 7^4 + 4^4
// As 1 = 14 is not a sum it is not included.
// The sum of these numbers is 1634 + 8208 + 9474 = 19316.
// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
internal sealed class Problem30 : IProblem
{
    private const int Power = 5;

    public void Solve()
    {
        IList<int> numbers = GetNumbers(Power);

        if (numbers.Count == 0)
        {
            Console.WriteLine("None.");
            return;
        }

        string sumString = string.Join(" + ", numbers);

        Console.WriteLine($"{sumString} = {numbers.Sum()}");
    }

    private IList<int> GetNumbers(int power)
    {
        IList<int> numbers = new List<int>();
        long limit = GetLimit(power);

        for (int i = 2; i < limit; i++)
        {
            if (IsSumOfPowers(i, power))
            {
                numbers.Add(i);
            }
        }

        return numbers;
    }

    private bool IsSumOfPowers(long number, int power)
    {
        long sum = 0;

        foreach (char digit in number.ToString())
        {
            sum += (long)Math.Pow(digit - '0', power);
        }

        return number == sum;
    }

    private long GetLimit(int power)
    {
        long max = (int)Math.Pow(9, power);
        int i = 1;

        while ((max * i).ToString().Length > i) i++;

        return GetTenXTimes(i);
    }

    private long GetTenXTimes(int x)
    {
        long result = 10;

        for (int i = 1; i < x; i++)
        {
            result *= 10;
        }

        return result;
    }
}
