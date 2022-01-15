using BenchmarkDotNet.Running;

namespace SpanOfTPerformance;

public static class Program
{
    private static void Main(string[] args)
    {
        BenchmarkRunner.Run<Bench>();
    }
}