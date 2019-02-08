using System.IO;
using BenchmarkDotNet.Attributes;

namespace Demo1_SpanMemory.Benchmarks
{
    [CoreJob]
    public class ReadBuffer
    {
        [Benchmark]
        public void ReadBytes()
        {
        }
    }
}