using System.Diagnostics;

namespace ProjectEulerSolution.Problems;

internal sealed class BenchmarkDecorator : IProblem
{
    private readonly IProblem _problem;
    private readonly Stopwatch _stopwatch;

    public BenchmarkDecorator(IProblem problem)
    {
        _problem = problem ?? throw new ArgumentNullException(nameof(problem));
        _stopwatch = new Stopwatch();
    }

    public void Solve()
    {
        _stopwatch.Restart();
        _problem.Solve();
        _stopwatch.Stop();

        Console.WriteLine($"\n{_stopwatch.Elapsed.TotalSeconds:F3} seconds");
    }
}
