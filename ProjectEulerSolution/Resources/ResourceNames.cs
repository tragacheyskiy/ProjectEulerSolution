namespace ProjectEulerSolution.Resources;

internal static class ResourceNames
{
    private const string Base = "ProjectEulerSolution.Resources";

    public static class Problem8
    {
        public static string Name { get; } = $"{Base}.{nameof(Problem8)}.1000_digit_number.txt";
    }

    public static class Problem11
    {
        public static string Name { get; } = $"{Base}.{nameof(Problem11)}.grid_20x20.txt";
    }

    public static class Problem13
    {
        public static string Name { get; } = $"{Base}.{nameof(Problem13)}.50_digit_numbers.txt";
    }

    public static class Problem22
    {
        public static string Name { get; } = $"{Base}.{nameof(Problem22)}.p022_names.txt";
    }
}
