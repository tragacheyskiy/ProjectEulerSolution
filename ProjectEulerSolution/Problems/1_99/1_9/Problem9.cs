namespace ProjectEulerSolution.Problems._1_99._1_9;

// https://projecteuler.net/problem=9
// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which, a^2 + b^2 = c^2
// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
// Find the product abc.
internal sealed class Problem9 : IProblem
{
    private class Triplet
    {
        public Triplet(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public int A { get; }
        public int B { get; }
        public int C { get; }
    }

    private const int SumCondition = 1000;

    public void Solve()
    {
        Triplet? triplet = GetTripletBySumCondition(SumCondition);

        if (triplet is null)
        {
            Console.WriteLine("Wrong condition");

            return;
        }

        long tripletProduct = triplet.A * triplet.B * triplet.C;

        Console.WriteLine($"{triplet.A} + {triplet.B} + {triplet.C} = {SumCondition}\n" +
            $"{triplet.A} x {triplet.B} x {triplet.C} = {tripletProduct}");
    }

    private Triplet? GetTripletBySumCondition(int condition)
    {
        int a, b, c;

        for (int i = 2; i < condition; i++)
        {
            for (int j = 1; j < i; j++)
            {
                a = j;
                b = i;
                c = (int)MathF.Sqrt(a * a + b * b);

                if (!IsPythagoreanTriplet(a, b, c))
                    continue;

                if ((a + b + c) == condition)
                {
                    return new Triplet(a, b, c);
                }
            }
        }

        return null;
    }

    private bool IsPythagoreanTriplet(int a, int b, int c)
    {
        if (a >= b || b >= c)
            return false;

        return a * a + b * b == c * c;
    }
}
