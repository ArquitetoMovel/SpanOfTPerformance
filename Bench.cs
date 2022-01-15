using BenchmarkDotNet.Attributes;

namespace SpanOfTPerformance;

[MemoryDiagnoser]
public class Bench
{
    private static readonly string dateAsString = "15 01 22";
 
    [Benchmark]
    public (int day, int month, int year) ParseDateAsString()
    {
        var day = int.Parse(dateAsString[..2]);
        var month = int.Parse(dateAsString.Substring(3, 2));
        var year = int.Parse(dateAsString.Substring(6, 2));

        return (day, month, year);
    }

    [Benchmark]
    public (int day, int month, int year) ParseDateAsSpanOfT()
    {
        ReadOnlySpan<char> spDateParse = dateAsString;
        var day = int.Parse(spDateParse[..2]);
        var month = int.Parse(spDateParse.Slice(3, 2));
        var year = int.Parse(spDateParse.Slice(6, 2));
        
        return (day, month, year);
    }   
}