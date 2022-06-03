namespace ProjectEulerSolution.Problems._1_99._1_9;

// https://projecteuler.net/problem=7
// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
// What is the 10 001st prime number?
internal sealed class Problem7 : IProblem
{
    private const int PrimeNumberPosition = 10001;

    public void Solve()
    {
        int result = GetPrimeNumber(PrimeNumberPosition);

        Console.WriteLine($"{PrimeNumberPosition} prime number = {result}");
    }

    private int GetPrimeNumber(int position)
    {
        int i = 2;
        int counter = 0;

        while (true)
        {
            if (IsPrimeNumber(i))
                counter++;

            if (counter == position)
                return i;

            i++;
        }
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
