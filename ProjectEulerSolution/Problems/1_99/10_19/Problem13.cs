using ProjectEulerSolution.Resources;
using System.Globalization;
using System.Reflection;

namespace ProjectEulerSolution.Problems._1_99._10_19;

// https://projecteuler.net/problem=13
// Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
internal sealed class Problem13 : IProblem
{
    private const int DigitsCount = 10;

    public void Solve()
    {
        IEnumerable<double> numbers = GetNumbers();

        string result = GetFirstTenDigitsOfTheSumOf(numbers);

        Console.WriteLine($"First ten digits of the sum: {result}");
    }

    private string GetFirstTenDigitsOfTheSumOf(IEnumerable<double> numbers)
    {
        return numbers.Sum().ToString(CultureInfo.InvariantCulture).Replace(".", null)[..DigitsCount];
    }

    private IEnumerable<double> GetNumbers()
    {
        using Stream? stream = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream(ResourceNames.Problem13.Name);

        if (stream == null)
            return Enumerable.Empty<double>();

        using StreamReader streamReader = new StreamReader(stream);

        string result = streamReader.ReadToEnd();

        return result
            .Split('\n')
            .Select(x => double.Parse(x.Insert(1, "."), CultureInfo.InvariantCulture));
    }
}
