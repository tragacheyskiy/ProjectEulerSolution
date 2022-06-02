namespace ProjectEulerSolution.Problems._1_99._20_29;

// https://projecteuler.net/problem=24
// A permutation is an ordered arrangement of objects.
// For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
// If all of the permutations are listed numerically or alphabetically, we call it lexicographic order.
// The lexicographic permutations of 0, 1 and 2 are:
// 012   021   102   120   201   210
// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
internal sealed class Problem24 : IProblem
{
    private const string Set = "0123456789";
    private const int Index = 1000000;

    public void Solve()
    {
        string permutation = GetPermutation(Set, Index);

        Console.WriteLine($"{Index}-th lexicographic permutation of ({Set}): {permutation}");
    }

    private string GetPermutation(string set, int index)
    {
        int i = 1;
        char[] values = set.ToCharArray();

        do
        {
            if (i++ == index)
                break;
        }
        while (NextPermutation(values));

        return new string(values);
    }

    private bool NextPermutation(char[] values)
    {
        int i = values.Length - 2;

        while (values[i + 1] < values[i])
        {
            i--;

            if (i < 0)
            {
                return false;
            }
        }

        int j = values.Length - 1;

        while (values[j] < values[i])
        {
            j--;
        }

        SwapValues(ref values[i], ref values[j]);

        i += 1;
        j = values.Length - 1;

        while (i < j)
        {
            SwapValues(ref values[i++], ref values[j--]);
        }

        return true;
    }

    private void SwapValues(ref char x, ref char y) => (y, x) = (x, y);
}
