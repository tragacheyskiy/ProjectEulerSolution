namespace ProjectEulerSolution.Problems._1_100._1_10;

// https://projecteuler.net/problem=5
// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
internal sealed class Problem5 : IProblem
{
    private const int MinValue = 2520;

    public void Solve()
    {
        int result = GetSmallestNumber();

        Console.WriteLine($"Smallest number = {result}");
    }

    private int GetSmallestNumber()
    {
        int i = MinValue;

        while (true)
        {
            i++;

            if (IsMatchCondition(i))
                return i;
        }
    }

    private bool IsMatchCondition(int number)
    {
        for (int i = 1; i <= 20; i++)
        {
            if (number % i != 0)
                return false;
        }

        return true;
    }
}
