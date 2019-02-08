using System;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Demo1_SpanMemory.Benchmarks
{
    [MemoryDiagnoser]
    [CoreJob]
    public class Arrays
    {
        private int[] _array;

        [GlobalSetup]
        public void Setup()
        {
            _array = Enumerable.Range(0, 100000).ToArray();
        }

        [Benchmark]
        public void WithoutSpan()
        {
            int[] groupSums = new int[1000];
            
            for (int i = 0; i < 1000; i++)
            {
                int[] group = new int[100];
                
                for (int j = 0; j < 100; j++)
                {
                    group[j] = _array[(i * 100) + j];
                }

                groupSums[i] = group.Sum();
            }
        }

        
        
        
        
        
        
        
        
        
        
        [Benchmark]
        public void WithSpan()
        {
            int[] groupSums = new int[1000];
            
            Span<int> arraySpan = _array.AsSpan();
            
            for (int i = 0; i < 1000; i++)
            {
                Span<int> slice = arraySpan.Slice((i * 100), 100);
                
                var sum = 0;
                for (int j = 0; j < 100; j++)
                {
                    sum += slice[j];
                }

                groupSums[i] = sum;
            }
        }
    }
}