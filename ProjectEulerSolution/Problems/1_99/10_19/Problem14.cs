namespace ProjectEulerSolution.Problems._1_99._10_19;

// https://projecteuler.net/problem=14
// The following iterative sequence is defined for the set of positive integers:
// n → n/2 (n is even)
// n → 3n + 1 (n is odd)
// Using the rule above and starting with 13, we generate the following sequence:
// 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms.
// Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
// Which starting number, under one million, produces the longest chain?
// NOTE: Once the chain starts the terms are allowed to go above one million.
internal sealed class Problem14 : IProblem
{
    private const int MaxNumber = 1000000;

    private readonly IDictionary<long, int> _cache = new Dictionary<long, int>();

    public void Solve()
    {
        int result = GetStartingNumberOfLongestChain(MaxNumber);

        Console.WriteLine($"Longest chain first number = {result}");
    }

    private int GetStartingNumberOfLongestChain(int maxNumber)
    {
        int startingNumber = 0;
        int longestChainLength = 0;

        for (int i = 3; i <= maxNumber; i++)
        {
            int length = GetChainLength(i);

            _cache[i] = length;

            if (length > longestChainLength)
            {
                startingNumber = i;
                longestChainLength = length;
            }
        }

        return startingNumber;
    }

    private int GetChainLength(int startingNumber)
    {
        int length = 1;
        long next = startingNumber;

        while (next > 1)
        {
            if (_cache.ContainsKey(next))
                return length + _cache[next];

            next = IsEvenNumber(next) ? next / 2 : next * 3 + 1;
            length++;
        }

        return length;
    }

    private bool IsEvenNumber(long number) => number % 2 == 0;
}
