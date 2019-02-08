using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Demo1_SpanMemory
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var benchmark = BenchmarkRunner.Run<Arrays>();
            //var benchmark = BenchmarkRunner.Run<RandomString>();
            //var benchmark = BenchmarkRunner.Run<RandomString>();
//
            
            List<string> chapters = new List<string>();
            using (var fileStream = File.OpenRead("HoundsOfBaskervilles.txt"))
            using (var streamReader = new StreamReader(fileStream))
            {
                while (!streamReader.EndOfStream)
                {
                    
                }
//                var line = binaryReader.ReadLine();
//                if (line != null && line.StartsWith("Chapter "))
//                {
//                    var stringBuilder = new StringBuilder();
//                }
//                    stringBuilder.Append(line)
            }
            
            

            //Console.WriteLine(buffer.Length);
        }
    }
}