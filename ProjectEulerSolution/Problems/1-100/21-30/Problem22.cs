using ProjectEulerSolution.Resources;
using System.Reflection;

namespace ProjectEulerSolution.Problems._1_100._21_30;

// https://projecteuler.net/problem=22
// Using names.txt(right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order.
// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.
// So, COLIN would obtain a score of 938 × 53 = 49714.
// What is the total of all the name scores in the file?
internal sealed class Problem22 : IProblem
{
    public void Solve()
    {
        string[] names = GetNames();

        int result = GetTotalPoints(names);

        Console.WriteLine($"Total points = {result}");
    }

    private int GetTotalPoints(string[] names)
    {
        int sum = 0;

        for (int i = 0; i < names.Length; i++)
        {
            int points = GetNamePoints(names[i], i + 1);

            sum += points;
        }

        return sum;
    }

    private int GetNamePoints(ReadOnlySpan<char> name, int index)
    {
        int sum = 0;

        foreach (char c in name)
        {
            sum += c == 'A' ? 1 : (c - 'A' + 1);
        }

        return sum * index;
    }

    private string[] GetNames()
    {
        using Stream? stream = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream(ResourceNames.Problem22.Name);

        if (stream == null)
            return Array.Empty<string>();

        using StreamReader streamReader = new StreamReader(stream);

        string result = streamReader.ReadToEnd();

        return result.Split(',').Select(x => x.Trim('"')).OrderBy(x => x).ToArray();
    }
}
