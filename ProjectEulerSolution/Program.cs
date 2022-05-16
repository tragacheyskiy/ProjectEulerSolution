using ProjectEulerSolution.Problems;
using ProjectEulerSolution.Problems._1_100._1_10;
using ProjectEulerSolution.Problems._1_100._11_20;
using ProjectEulerSolution.Problems._1_100._21_30;

internal class Program
{
    private static void Main(string[] args)
    {
        CreateProblem().Solve();

        Console.WriteLine("\nSuccess!");
        Console.ReadKey(true);
    }

    private static IProblem CreateProblem()
    {
        return new Problem21();
    }
}