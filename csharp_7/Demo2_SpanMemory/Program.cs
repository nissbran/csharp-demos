using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Demo2_SpanMemory
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //var benchmark = BenchmarkRunner.Run<Arrays>();
            //var benchmark = BenchmarkRunner.Run<RandomString>();

            FirstPart();
            await SecondPart();
        }

        private static void FirstPart()
        {
            // Without span
            int[] arrayOfInts = new int[5] {1, 2, 3, 4, 5};

            int[] subArray = new int[2];

            Array.Copy(arrayOfInts, 3, subArray, 0, 2);
            Console.WriteLine(string.Join(", ", subArray.Select(i => i.ToString())));

            // With span
            Span<int> spanOfInts = arrayOfInts.AsSpan().Slice(3, 2);
            Span<int> spanOfInts2 = new[] {1, 2, 3, 4, 5};
            Span<int> sliceOfInts = spanOfInts2.Slice(3, 2);

            foreach (var integer in spanOfInts)
            {
                Console.Write(integer.ToString() + " ");
            }
            Console.WriteLine();
            
            // Stackalloc
            Span<int> stackInts = stackalloc [] {1, 2, 3, 4, 5, 6};
            foreach (var integer in stackInts)
            {
                Console.Write(integer.ToString() + " ");
            }
            Console.WriteLine();

            // Unmanaged memory
            int bufferSize = 128;
            IntPtr unmanagedBufferPointer = Marshal.AllocHGlobal(bufferSize);

            try
            {
                Span<byte> spanOfUnmanagedMemory;
                unsafe
                {
                    spanOfUnmanagedMemory = new Span<byte>(unmanagedBufferPointer.ToPointer(), 128);
                }

                Span<int> intSpan = MemoryMarshal.Cast<byte, int>(spanOfUnmanagedMemory);
                
                Console.WriteLine(intSpan.Length);
                Console.WriteLine(intSpan[0]);
            }
            finally{ Marshal.FreeHGlobal(unmanagedBufferPointer);}

            // Strings
            string myString = "Teststring";
            ReadOnlySpan<char> myStringAsSpan = myString.AsSpan();
            
            Console.WriteLine(myStringAsSpan[3]);
        }

        private static async Task SecondPart()
        {
            Memory<byte> memory = await File.ReadAllBytesAsync("HoundsOfBaskervilles.txt");

            var memoryHolder = new MyMemoryHolder(memory);

            memoryHolder.Slice();
        }
    }
}