using System.Collections.Generic;
using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Demo2_SpanMemory.Benchmarks
{
    [CoreJob]
    public class ReadBuffer
    {
        private static string Test = "End of the Project Gutenberg EBook of The Hound of the Baskervilles, by Arthur Conan Doyle";
        
        [Benchmark]
        public void ReadChaptersStreamBytes()
        {
            List<string> chapters = new List<string>();
            using (var fileStream = File.OpenRead("HoundsOfBaskervilles.txt"))
            using (var streamReader = new StreamReader(fileStream))
            {
                StringBuilder stringBuilder = null;
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line) && line.StartsWith("Chapter "))
                    {
                        if (stringBuilder != null)
                            chapters.Add(stringBuilder.ToString());
                        stringBuilder = new StringBuilder();
                    }

                    if (!string.IsNullOrWhiteSpace(line) && line.StartsWith(Test))
                        break;

                    stringBuilder?.Append(line);
                }
            }
        }
    }
}