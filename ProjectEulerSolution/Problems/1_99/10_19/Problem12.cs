﻿namespace ProjectEulerSolution.Problems._1_99._10_19;

// https://projecteuler.net/problem=12
// The sequence of triangle numbers is generated by adding the natural numbers.
// So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28.
// The first ten terms would be:
// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
// Let us list the factors of the first seven triangle numbers:
// 1: 1
// 3: 1,3
// 6: 1,2,3,6
// 10: 1,2,5,10
// 15: 1,3,5,15
// 21: 1,3,7,21
// 28: 1,2,4,7,14,28
// We can see that 28 is the first triangle number to have over five divisors.
// What is the value of the first triangle number to have over five hundred divisors?
internal sealed class Problem12 : IProblem
{
    private const int MinDivisorsCount = 500;
    private const int FirstTriangleNumber = 1;

    public void Solve()
    {
        int result = GetTriangleNumber();

        Console.WriteLine($"First triangle number with over five hundred divisors: {result}");
    }

    private int GetTriangleNumber()
    {
        int previousNumber = FirstTriangleNumber;
        int currentNumber = 0;
        int divisorsCount = 0;
        int i = 2;

        while (divisorsCount < MinDivisorsCount)
        {
            currentNumber = previousNumber + i++;
            previousNumber = currentNumber;

            divisorsCount = GetDivisorsCount(currentNumber);
        }

        return currentNumber;
    }

    private int GetDivisorsCount(int number)
    {
        int max = (int)MathF.Sqrt(number);
        int result = max * max == number ? 3 : 2;

        for (int i = 2; i < max; i++)
        {
            if (number % i == 0)
            {
                result += 2;
            }
        }

        return result;
    }
}