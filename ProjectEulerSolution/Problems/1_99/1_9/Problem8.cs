using ProjectEulerSolution.Resources;
using System.Reflection;

namespace ProjectEulerSolution.Problems._1_99._1_9;

// https://projecteuler.net/problem=8
// The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
// Find the thirteen adjacent digits in the 1000-digit number that have the greatest product.
// What is the value of this product?
internal sealed class Problem8 : IProblem
{
    private class SequenceProduct
    {
        public SequenceProduct(char[] sequence, long product)
        {
            Sequence = sequence;
            Product = product;
        }

        public char[] Sequence { get; }
        public long Product { get; }
    }

    private const int SequenceLength = 13;

    public void Solve()
    {
        string thousandDigitNumber = GetThousandDigitNumber();

        SequenceProduct result = GetGreatestSequenceProduct(thousandDigitNumber);

        string sequenceString = string.Join(" x ", result.Sequence);

        Console.WriteLine($"{sequenceString} = {result.Product}");
    }

    private SequenceProduct GetGreatestSequenceProduct(ReadOnlySpan<char> number)
    {
        long maxSequenceProduct = 0;
        ReadOnlySpan<char> sequence = default;

        for (int i = 0; i < number.Length - SequenceLength; i++)
        {
            var slice = number.Slice(i, SequenceLength);
            int indexOfZero = slice.IndexOf('0');

            if (indexOfZero != -1)
            {
                i += indexOfZero;

                continue;
            }

            long sequenceProduct = GetSequenceProduct(slice);

            if (sequenceProduct > maxSequenceProduct)
            {
                maxSequenceProduct = sequenceProduct;
                sequence = slice;
            }
        }

        return new SequenceProduct(sequence.ToArray(), maxSequenceProduct);
    }

    private long GetSequenceProduct(ReadOnlySpan<char> sequence)
    {
        long result = 1;

        foreach (char digit in sequence)
        {
            result *= digit - '0';
        }

        return result;
    }

    private string GetThousandDigitNumber()
    {
        using Stream? stream = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream(ResourceNames.Problem8.Name);

        if (stream == null)
            return string.Empty;

        using StreamReader streamReader = new StreamReader(stream);

        return streamReader.ReadToEnd();
    }
}
