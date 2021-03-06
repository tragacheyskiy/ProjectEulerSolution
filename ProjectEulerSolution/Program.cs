using ProjectEulerSolution.Problems;
using ProjectEulerSolution.Problems._1_99._1_9;
using ProjectEulerSolution.Problems._1_99._10_19;
using ProjectEulerSolution.Problems._1_99._20_29;
using ProjectEulerSolution.Problems._1_99._30_39;

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
        return new BenchmarkDecorator(new Problem26());
    }
}