using System;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Demo1_SpanMemory.Benchmarks
{
    [MemoryDiagnoser]
    [CoreJob]
    public class RandomString
    {
        [Benchmark]
        public void Concat()
        {
            var randomString = string.Empty;
            var random = new Random();
            
            for (int i = 0; i < 100000; i++)
            {
                randomString = randomString + random.Next(0, 9);
            }
        }

        [Benchmark]
        public void StringBuilder()
        {
            var random = new Random();
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                stringBuilder.Append(random.Next(0, 9));
            }

            var randomString = stringBuilder.ToString();
        }

        [Benchmark]
        public void StringCreate()
        {
            var random = new Random();
            var randomString = string.Create(100000, random, (span, r) =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    span[i] = (char)r.Next(0,9);
                }
            });
        }
    }
}